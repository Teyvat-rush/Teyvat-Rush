using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProducedSun : MonoBehaviour
{
  public float duration;
  private float timer;
    public float g = -4;//重力加速度，正方向为y轴正方向
    public float vy0 = 2;//竖直方向初速度，正方向为y轴正方向
    public float v_Inflation = 0.5f; //膨胀速度
    private Rigidbody2D rb;
    private Animator am;
    // Start is called before the first frame update
    void Start()
    {
    timer = 0;
        rb= GetComponent<Rigidbody2D>();
        am= GetComponent<Animator>();
        rb.velocity = new Vector2(Random.Range(-0.4f, 1.6f), vy0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.transform.localPosition.y<-0.45)
        {
            rb.velocity = new Vector2(0,0);
      SwitchAnim();
        }else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + g * Time.deltaTime);
        }

        if(transform.localScale.x<1)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime *v_Inflation, transform.localScale.y + Time.deltaTime *v_Inflation);
        }
        am.SetFloat("vx",rb.velocity.x);
        am.SetFloat("vy",rb.velocity.y);
    }
  private void SwitchAnim()
  {
    timer += Time.deltaTime;
    if(timer>=duration)
    {
      timer = 0;
      am.SetBool("Disappear", true);
    }
  }
  private void Disappear()
  {
    GameObject.Destroy(gameObject);
  }
  private void OnMouseDown()
  {
    int i = Random.Range(1, 4);
    SoundManager.instance.PlaySound(Globals.PickSun + i);
    // 将屏幕坐标转化为世界坐标
    Vector3 sunNumPos = (UIManager.instance.GetSunNumTextPos());
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
