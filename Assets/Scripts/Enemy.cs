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
  public float health=100;
  private float currentHealth;
  private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    isDead = false;
    currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
    if(!isDead)
    {
      Movement();
    }
    }
  void Movement()
  {
      rb.velocity = new Vector2(-Speed, 0);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      /*切换动画*/
      rb.velocity = new Vector2(0, 0);
    }
  }
  private void OnCollisionEnter2D(Collider2D collision)
  {
    
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
          Plant plant = collision.GetComponent<Plant>();
          float newHealth = plant.ChangeHealth(-damage);
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
  public void ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if(currentHealth<=0)
    {
      GameObject.Destroy(gameObject);
    }
  }
}
  

