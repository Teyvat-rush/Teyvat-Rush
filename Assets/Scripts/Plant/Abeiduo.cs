using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeiduo : Plant
{
  private float timer;//计时器
  public float ReadyTime;//准备时间
  private bool ready;
  public float damage;
  // Start is called before the first frame update
 protected override void Start()
    {
    base.Start();
    ready = false;
    }

    // Update is called once per frame
    void Update()
    {
    Ready();
    }
  private void Ready()
  {
    timer += Time.deltaTime;
    if(timer>=ReadyTime)
    {
      ready = true;
      currentHealth = 1000000;
    }
  }
  
  public void BoomOver()
  {
    GameObject.Destroy(gameObject);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy"&&ready)
    {
      animator.SetBool("PrepareOver", true);
      collision.GetComponent<Enemy>().ChangeHealth(-damage);
    }
  }
}
