using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mona : Plant
{
  public GameObject SunPrefab;
    public float ReadyTime;
  private float timer;
    void Start()
    {
    timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    timer += Time.deltaTime;
    BornSun();
    }
  void BornSun()
  {
    if(timer>=ReadyTime)
    {
      timer =0;
      GameObject ProducedSun =  Instantiate(SunPrefab);
      ProducedSun.transform.parent = transform.parent.transform;
      ProducedSun.transform.localPosition = Vector3.zero;
    }
  }

}
