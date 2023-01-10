using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QQRen : Enemy
{
    public float T;
    
    public float dyingTimer;//死亡动画计时器
    public float lastDamageTime = 0;
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
        T = Time.time;
        if (!isDead)
        {
            Movement();
        }else
        {
            Instantiate(EnemyDieParticle, transform.position, transform.rotation);
            Destroy(gameObject);
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
            /*切换动画*/
            anim.SetBool("Attack", true);
            anim.SetBool("enter", true);
            anim.SetBool("stay", false);
            anim.SetBool("exit", false);
            Speed = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("enter", false);
            anim.SetBool("stay",true);
            anim.SetBool("exit", false);
            /*切换动画*/
            if (lastDamageTime==0)
            {
                lastDamageTime= Time.time;
            }
            damageTimer = Time.time-lastDamageTime;
            if (damageTimer >= damageInterval)
            {
                lastDamageTime = 0;
                Plant plant = collision.GetComponent<Plant>();
                float newHealth = plant.ChangeHealth(-damage);
                if (newHealth <= 0)
                {
                    /*切换动画*/
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
            /*切换动画*/
            anim.SetBool("Attack", false);
            Speed = 0.28f;
            lastDamageTime = 0;
            anim.SetBool("enter", false);
            anim.SetBool("stay", false);
            anim.SetBool("exit", true);
        }
    }
    
}
