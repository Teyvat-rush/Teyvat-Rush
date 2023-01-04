using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qqRen_Stick_Shield : MonoBehaviour
{
    public GameObject qqRen_Stick_Shield100;
  public GameObject qqRen_Stick_Shield50;
  public GameObject qqRen_Stick_Shield20;
  private Rigidbody2D rigidbody2D;
  public GameObject EnemyDieParticle;
  private BoxCollider2D boxCollider;
  private Animator animator;
  public float damage;//伤害值
  public float Health;
  private float currentHealth;
  private bool isDead;
  public float Speed;//移动速度
  void Start()
    {
    rigidbody2D = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();
    animator = GetComponent<Animator>();
    isDead = false;
    currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
    {
      Move();
    }
    else
    {
      Instantiate(EnemyDieParticle, transform.position, transform.rotation);
      Destroy(gameObject);
    }
  }
  private void Move()
  {
    rigidbody2D.velocity = new Vector2(-Speed, rigidbody2D.velocity.y);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Plant")
    {
      Speed = 0;
      animator.SetBool("Walk", false);
      animator.SetBool("Attack", true);
    }
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if(collision.tag=="Plant")
    {
      Plant plant = collision.GetComponent<Plant>();
      float newHealth = plant.ChangeHealth(-damage);
      if (newHealth <= 0)
      {
        Destroy(plant.gameObject);
        animator.SetBool("Walk", true);
        animator.SetBool("Attack", false);
        Speed = 0.28f;
      }
    }
  }
  public void ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, Health);
    if (currentHealth <= 0)
    {
      isDead = true;
      GameManager.instance.EnemyDied(gameObject);
    }
  }
}
