using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anbo : Plant
{
  public GameObject Explode;//爆炸实质
  protected override void Start()
  {
    base.Start();
    health = 10000000;
  }

  private void BOOM()
  {
    Explode.SetActive(true);
  }
  private void Boomover()
  {
    GameObject.Destroy(gameObject);
  }
  
}
