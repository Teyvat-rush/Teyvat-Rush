using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
  private Transform Bornposition;
  public GameObject LeftWing;
  public GameObject RightWing;
    // Start is called before the first frame update
    void Start()
    {
    Bornposition = transform;
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    anim.SetBool("Jump", true);
    currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
    if (!isDead)
    {
      Movement();
      if(currentHealth<=health/2)
      {
        LeftWing.SetActive(false);
        RightWing.SetActive(false);
      }
    }
    else
    {
      Instantiate(EnemyDieParticle, transform.position, transform.rotation);
      Destroy(gameObject);
    }
  }
  void Movement()
  {
    rb.velocity = new Vector2(-Speed, rb.velocity.y);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag=="Plant")
    {
      anim.SetBool("Jump", false);
      anim.SetBool("Attack", true);
      PauseMove();
      transform.position = new Vector2(transform.position.x, Bornposition.position.y);
    }
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      anim.SetBool("Jump", false);
      anim.SetBool("Attack", true);
      PauseMove();
      damageTimer += Time.deltaTime;
      if(damageTimer>=damageInterval)
      {
        damageTimer = 0;
        Plant plant = collision.GetComponent<Plant>();
        float newHealth = plant.ChangeHealth(-damage);
        if (newHealth <= 0)
        {
          anim.SetBool("Attack", false);
          anim.SetBool("Jump", true);
          Speed = 0.8f;
        }
      }
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    if(collision.tag=="Plant")
    {
      anim.SetBool("Attack", false);
      anim.SetBool("Jump", true);
      ContinueMove();
    }
  }
  public void PauseMove()
  {
    Speed = 0;
  }
  public void ContinueMove()
  {
    Speed = 0.8f;
  }
}
