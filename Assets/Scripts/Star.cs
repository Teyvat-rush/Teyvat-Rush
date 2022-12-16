using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
  public float duration;//持续时间
  private float timer;//计时器
  private Animator anim;
  private float speed = 10.0f;
  // Start is called before the first frame update
  void Start()
    {
    anim = GetComponent<Animator>();
    timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    SwitchAnim();
    }

  void SwitchAnim()
  {
    if (anim.GetBool("idle"))
    {
      timer += Time.deltaTime;
      if (timer >= duration)
      {
        timer = 0;
        anim.SetBool("Disappear",true);
      }
    }
  }
  public void Disappearing()
  {
    GameObject.Destroy(gameObject);
  }
  private void OnMouseDown()
  {
    
    // 将屏幕坐标转化为世界坐标
    Vector3 sunNumPos = Camera.main.ScreenToWorldPoint(UIManager.instance.GetSunNumTextPos());
    sunNumPos = new Vector3(sunNumPos.x, sunNumPos.y, 0);
    FlyAnimation(sunNumPos);
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
    GameManager.instance.starNum += 25;
  }
}
