using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlant : MonoBehaviour
{
  private Rigidbody2D rb;
  private CapsuleCollider2D coll;
  public float interval;//子弹生成的间隔时间
  public float timer;//计时器
  public GameObject Bullet;//子弹的源
  public Transform BulletPos;//子弹生成的位置
  public float health;
  private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    timer += Time.deltaTime;
    if(timer>=interval)
    {
      timer = 0;
      Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }
    }
  public float ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if(currentHealth<=0)
    {
      GameObject.Destroy(gameObject);
    }
    return currentHealth;
  }
}
