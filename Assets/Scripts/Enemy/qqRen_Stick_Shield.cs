using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class qqRen_Stick_Shield : Enemy
{
  public GameObject shield_100;
  public GameObject shield_50;
  public GameObject shield_20;
  public GameObject mask_100;
  public GameObject mask_50;
  public bool isAttack;
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
    isAttack = false;
    if(isAttack)
    {
      Speed = 0;
    }
    if (!isDead)
    {
      Movement();
    }
    else
    {
      Instantiate(EnemyDieParticle, transform.position, transform.rotation);
      Destroy(gameObject);
    }
    if (currentHealth <= health*2 / 3)
    {
      shield_100.SetActive(false);
      shield_50.SetActive(true);
      if(currentHealth<=health/2)
      {
        shield_50.SetActive(false);
        shield_20.SetActive(true);
        if(currentHealth<=health/3)
        {
          shield_20.SetActive(false);
          if(currentHealth<=health*2/10)
          {
            mask_100.SetActive(false);
            mask_50.SetActive(true);
          }
        }
      }
    }
  }
  void Movement()
  {
    rb.velocity = new Vector2(-Speed, 0);
  }

  
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      isAttack = true;
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
          isAttack = false;
          anim.SetBool("Attack", false);
          Speed = 0.28f;
        }
      }
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    isAttack = false;
      Speed = 0.28f;
      anim.SetBool("Attack", false);
  }

}
