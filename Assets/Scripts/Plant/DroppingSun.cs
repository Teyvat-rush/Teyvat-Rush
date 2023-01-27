using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSun : MonoBehaviour
{
  private GameObject Menu;
  public float duration;//持续时间
  private float timer;//计时器
  private Animator anim;
  private Rigidbody2D rb;
  private float speed = 10.0f;
  public float DroppingSpeed;
  Vector2 Left = new Vector2(-4.83f,5.36f);
  Vector2  Right = new Vector2(8.32f,5.36f);
  Vector2  Bottom=new Vector2(0,-4.16f);
  Vector2 BornPos;
  Vector2 TargetPos;
  // Start is called before the first frame update
  void Start()
    {
    Menu = GameObject.Find("Canvas");
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    timer = 0;
    BornPos = new Vector2(Random.Range(Left.x, Right.x), Left.y);
    transform.position = new Vector2(BornPos.x, BornPos.y);
    TargetPos = new Vector2(BornPos.x, Random.Range(BornPos.y-4, Bottom.y-3));
    rb.velocity = new Vector2(0, -DroppingSpeed);
    
  }
  // Update is called once per frame
  void Update()
    {
    if (Mathf.Abs(transform.position.y - TargetPos.y) <= 0.5f)
    {
      rb.velocity = new Vector2(0, 0);
      SwitchAnim();
    }
    }

  void SwitchAnim()
  {
    
      timer += Time.deltaTime;
      if (timer >= duration)
      {
        timer = 0;
        anim.SetBool("Disappear",true);
      }
    
  }
  public void Disappearing()
  {
    GameObject.Destroy(gameObject);
  }
  private void OnMouseDown()
  {
    if(Menu.GetComponent<Menu>().isPause==false)
    {
      GameManager.instance.starNum += 25;
      int i = Random.Range(1, 4);
      SoundManager.instance.PlaySound(Globals.PickSun + i);
      rb.velocity = new Vector2(0, 0);
      // 将屏幕坐标转化为世界坐标
      Vector3 sunNumPos = (UIManager.instance.GetSunNumTextPos());
      sunNumPos = new Vector3(sunNumPos.x, sunNumPos.y, 0);
      FlyAnimation(sunNumPos);
    }
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
