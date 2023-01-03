using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Plant
{
  private float timer;//计时器
  public float ReadyTime;//准备时间
  private Animator animator;
  public bool boom;
  // Start is called before the first frame update
  void Start()
    {
    animator = GetComponent<Animator>();
    boom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void Ready()
  {
    timer += Time.deltaTime;
    if(timer>=ReadyTime&&boom)
    {
      animator.SetBool("PrepareOver",true);
    }
  }
  public void Boom()
  {
    boom = true;
  }
  public void BoomOver()
  {
    GameObject.Destroy(gameObject);
  }
}
