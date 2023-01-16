using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
  private float BornY;
  public GameObject LeftWing;
  public GameObject RightWing;
  public bool isAttack;
    // Start is called before the first frame update
   void Start()
    {
    BornY = transform.position.y;
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    anim.SetBool("Jump", true);
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
    rb.velocity = new Vector3(-Speed, rb.velocity.y,0);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Plant")
    {
      isAttack = true;
      anim.SetBool("Jump", false);
      anim.SetBool("Attack", true);
      Speed = 0;
      transform.position = new Vector3(transform.position.x, BornY, transform.position.z);
      damageTimer += Time.deltaTime;
      if(damageTimer>=damageInterval)
      {
        damageTimer = 0;
        Plant plant = collision.GetComponent<Plant>();
        float newHealth = plant.ChangeHealth(-damage);
        if (newHealth <= 0)
        {
          isAttack = false;
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
      isAttack = false;
      anim.SetBool("Attack", false);
      anim.SetBool("Jump", true);
      ContinueMove();
            float ran1 = Random.Range(50, 101);
            int ran2 =Random.Range(0,2);
            if(ran2==0)
            {
                transform.localPosition = new Vector3(transform.localPosition.x+ran1 / 300, -0.8f, transform.localPosition.z);
            }else
            {
                transform.localPosition = new Vector3(transform.localPosition.x -ran1 / 300, -0.8f, transform.localPosition.z);
            }

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
