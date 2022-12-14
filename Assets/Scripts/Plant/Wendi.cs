using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wendi : Plant
{
  
  private AudioSource audioSource;
  public float interval;//子弹生成的间隔时间
  public float timer;//计时器
  public GameObject Bullet;//子弹的源
  public Transform BulletPos;//子弹生成的位置
    // Start is called before the first frame update
    protected override void Start()
    {
    base.Start();
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
  
}
