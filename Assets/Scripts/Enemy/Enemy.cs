using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  protected Rigidbody2D rb;
  protected Collider2D coll;
  protected Animator anim;
  public GameObject EnemyDieParticle;
  public float Speed;
  public float damage;//伤害值
  public float health = 100;
  public float currentHealth;
  protected bool isDead;
  public float damageInterval;//攻击间隔
  public float damageTimer;//计时器
  public void ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if (currentHealth <= 0)
    {
      isDead = true;
      GameManager.instance.EnemyDied(gameObject,gameObject.transform.position);
    }
  }
}
