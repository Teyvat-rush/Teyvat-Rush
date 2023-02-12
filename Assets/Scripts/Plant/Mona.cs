using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mona : Plant
{
  public GameObject SunPrefab;
    public float ReadyTime;
  private float timer;
  public GameObject Monaa;
    protected override void Start()
    {
    base.Start();
    timer = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
    base.Update();
    if(PlantAwake)
    {
      timer += Time.deltaTime;
      BornSun();
    }
    }
  void BornSun()
  {
    if(timer>=ReadyTime)
    {
      timer =0;
      GameObject ProducedSun =  Instantiate(SunPrefab);
      ProducedSun.transform.parent = Monaa.transform;
      ProducedSun.transform.localPosition = new Vector3(-0.7f,-0.4f,0);
    }
  }

}
