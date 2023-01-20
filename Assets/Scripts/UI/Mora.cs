using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mora : MonoBehaviour
{
  private CircleCollider2D collider2D;
  private Rigidbody2D rb;
  private Animator animator;
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    collider2D = GetComponent<CircleCollider2D>();
    animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    
    }
  
  private void OnMouseDown()
  {
    animator.SetBool("Fly", true);
    int i = Random.Range(1, 3);
    SoundManager.instance.PlaySound(Globals.PickMora + i);
    if (this.name == "Small_Mora")
    {
      DataManager.instance.coin.num += 16;
    }
    else if (this.name== "Big_Mora")
    {
      DataManager.instance.coin.num += 80;
    }
    else if (this.name == "Big_PaiMora")
    {
      DataManager.instance.coin.num -= 9;
    }
    else if (this.name == "Small_PaiMora")
    {
      DataManager.instance.coin.num -= 45;
    }
        string json_Mora = JsonUtility.ToJson(DataManager.instance.coin);
        string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
        using (StreamWriter streamWriter = new StreamWriter(filepath_Mora))
        {
            streamWriter.WriteLine(json_Mora);
            streamWriter.Close();
            streamWriter.Dispose();
        }

        // 将屏幕坐标转化为世界坐标
        Vector3 MoraNumPos = Camera.main.ScreenToWorldPoint(UIManager.instance.GetMoraNumTextPos());
    MoraNumPos = new Vector3(MoraNumPos.x, MoraNumPos.y, 0);
    FlyAnimation(MoraNumPos);
  }
  private void FlyAnimation(Vector3 pos)
  {
    StartCoroutine(DoFly(pos));
  }
  IEnumerator DoFly(Vector3 pos)
  {
    // 获得阳光到阳光文本的方向向量
    // Vector3.normalized的特点是当前向量是不改变的并且【返回】一个新的规范化的向量（长度为1）；
    // Vector3.Normalize的特点是改变当前向量，然后当前向量长度是1
    Vector3 direction = (pos - transform.position).normalized;
    while (Vector3.Distance(pos, transform.position) > 0.5f)
    {
      yield return new WaitForSeconds(0.03f);
      transform.Translate(direction); // 往这个方向移动
    }
    GameObject.Destroy(gameObject);

  }
}
