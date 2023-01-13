using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeiduo : Plant
{
  public GameObject Explode;
  private float timer;//计时器
  public float ReadyTime;//准备时间
  private bool ready;
  public float damage;
  // Start is called before the first frame update
 protected override void Start()
    {
    base.Start();
    ready = false;
    timer = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
    base.Update();
    if(PlantAwake)
    {
      Ready();
      timer += Time.deltaTime;
    }
    }
  private void Ready()
  {
    if(timer>=ReadyTime)
    {
      ready = true;
      health = 1000000;
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
      Explode.SetActive(true);
    }
  }
}
