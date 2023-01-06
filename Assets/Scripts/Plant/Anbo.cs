using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anbo : Plant
{
  public float range;
  protected override void Start()
  {
    base.Start();
    health = 10000000;
  }
  public void BOOM()
  {
    Collider[] colliders = Physics.OverlapBox(transform.position,new Vector3(range,range,transform.localScale.z),Quaternion.identity,2);
    for(int i=0;i<colliders.Length;i++)
    {
      if(colliders[i].tag=="Enemy")
      {
        Destroy(colliders[i].gameObject);
        Debug.Log(colliders[i].name);
      }
    }
    GameObject.Destroy(gameObject);
  }
  private void OnDrawGizmosSelected()
  {
    Gizmos.DrawWireCube(transform.position,new Vector3(range,range,transform.localScale.z));
  }
}
