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
  public GameObject MoraBag;
  public void ChangeHealth(float num)
  {
    int i = Random.Range(1, 3);
    SoundManager.instance.PlaySound(Globals.EnemyGotAttack + i);
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if (currentHealth <= 0)
    {
      MoraBag.transform.parent = GameManager.instance.transform;
      CreateMora(); 
      isDead = true;
      GameManager.instance.EnemyDied(gameObject);
      
    }
  }
  private void CreateMora()
  {
    int i = Random.Range(1, 101);
    if (i <= 8)
    {
      int j = Random.Range(1, 3);
      SoundManager.instance.PlaySound(Globals.FallMora + j);
      GameObject big_mora = Instantiate(Big_Mora);
      big_mora.transform.parent = MoraBag.transform;
      big_mora.transform.localPosition = Vector3.zero;
      big_mora.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
    }
    else if (i > 8 && i <= 30)
    {
      int j = Random.Range(1, 3);
      SoundManager.instance.PlaySound(Globals.FallMora + j);
      GameObject small_mora = Instantiate(Small_Mora);
      small_mora.transform.parent = MoraBag.transform;
      small_mora.transform.localPosition = Vector3.zero;
      small_mora.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
    }
    else if (i > 30 && i <= 38)
    {
      int j = Random.Range(1, 3);
      SoundManager.instance.PlaySound(Globals.FallMora + j);
      GameObject small_paimora = Instantiate(Small_PaiMora);
      small_paimora.transform.parent = MoraBag.transform;
      small_paimora.transform.localPosition = Vector3.zero;
      small_paimora.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
    }
    else if (i > 38 && i <= 40)
    {
      int j = Random.Range(1, 3);
      SoundManager.instance.PlaySound(Globals.FallMora + j);
      GameObject big_paimora = Instantiate(Big_PaiMora);
      big_paimora.transform.parent = MoraBag.transform;
      big_paimora.transform.localPosition = Vector3.zero;
      big_paimora.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
    }
  }
}
