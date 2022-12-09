using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
  private Rigidbody2D rb;
  private Collider2D coll;
  public float Speed;
  public float damage;//伤害值
  public float damageInterval;//攻击间隔
  private float damageTimer;//计时器
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    Movement();
    
    }
  void Movement()
  {
      rb.velocity = new Vector2(-Speed, 0);
  }
  
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Plant")
      {
      /*切换动画*/
      rb.velocity = new Vector2(0, 0);
      }
  }
    private void OnTriggerStay2D(Collider2D collision)
  {
      if (collision.tag == "Plant")
      {
        /*切换动画*/
        damageTimer += Time.deltaTime;
        if(damageTimer>=damageInterval)
        {
          damageTimer = 0;
          TestPlant Wendi = collision.GetComponent<TestPlant>();
          float newHealth = Wendi.ChangeHealth(-damage);
          if(newHealth<=0)
          {
            /*切换动画*/
          }
        }
      }
    }
    private void OnTriggerExit2D(Collider2D collision)
  {
      if (collision.tag == "Plant")
      {
        /*切换动画*/
      }
    }
}
  

