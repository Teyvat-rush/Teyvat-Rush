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
  public GameObject Big_Mora;
  public GameObject Small_Mora;
  public GameObject Big_PaiMora;
  public GameObject Small_PaiMora;
  public void ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if (currentHealth <= 0)
    {
      int i = Random.Range(1, 101);
      if(i<=8)
      {
       GameObject big_mora= Instantiate(Big_Mora);
        big_mora.transform.parent = transform;
        big_mora.transform.localPosition = new Vector2(-0.738f, -0.561f);
        big_mora.transform.parent = GameManager.instance.transform;
      }
      else if(i>8&&i<=30)
      {
       GameObject small_mora =Instantiate(Small_Mora);
        small_mora.transform.parent = transform;
        small_mora.transform.localPosition = new Vector2(-0.738f, -0.561f);
        small_mora.transform.parent = GameManager.instance.transform;
      }
      else if(i>30&&i<=38)
      {
        GameObject small_paimora = Instantiate(Small_PaiMora);
        small_paimora.transform.parent = transform;
        small_paimora.transform.localPosition = new Vector2(-0.738f, -0.561f);
        small_paimora.transform.parent = GameManager.instance.transform;
      }
      else if(i>38&&i<=40)
      {
        GameObject big_paimora = Instantiate(Big_PaiMora);
        big_paimora.transform.parent = transform;
        big_paimora.transform.localPosition = new Vector2(-0.738f, -0.561f);
        big_paimora.transform.parent = GameManager.instance.transform;
      }
      isDead = true;
      GameManager.instance.EnemyDied(gameObject);
    }
  }
}
