using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qqRen_Stick : Enemy
{
  public GameObject mask100;
  public GameObject mask50;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    anim = GetComponent<Animator>();
    isDead = false;
    currentHealth = health;
  }

  // Update is called once per frame
  void Update()
  {
    if (!isDead)
    {
      Movement();
    }
    else
    {
      Instantiate(EnemyDieParticle, transform.position, transform.rotation);
      Destroy(gameObject);
    }
    if (currentHealth <= health / 2)
    {
      mask100.SetActive(false);
      mask50.SetActive(true);
    }
  }
  void Movement()
  {
    rb.velocity = new Vector2(-Speed, 0);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      anim.SetBool("Attack", true);
      Speed = 0;
    }
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      Speed = 0;
      anim.SetBool("Attack", true);
      damageTimer += Time.deltaTime;
      if (damageTimer >= damageInterval)
      {
        damageTimer = 0;
        Plant plant = collision.GetComponent<Plant>();
        float newHealth = plant.ChangeHealth(-damage);
        if (newHealth <= 0)
        {
          anim.SetBool("Attack", false);
          Speed = 0.28f;
        }
      }
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.tag == "Plant")
    {
      Speed = 0.28f;
      anim.SetBool("Attack", false);
    }
  }
}
