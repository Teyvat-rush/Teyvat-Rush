using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anbo : Plant
{
  public Transform BoomCenter;
  public float range;
  private Animator animator;
  private void Start()
  {
    currentHealth = 10000000;
    animator = GetComponent<Animator>();
  }
  public void BOOM()
  {
    Collider[] colliders = Physics.OverlapBox(transform.position,new Vector3(range,range,1000000),Quaternion.identity);
    for(int i=0;i<colliders.Length;i++)
    {

        Destroy(colliders[i].gameObject);
        print(colliders[i].gameObject.name);

    }
    GameObject.Destroy(gameObject);
  }
  private void OnDrawGizmos()
  {
    Gizmos.DrawWireCube(transform.position,new Vector3(range*2,range*2,transform.localScale.z));
  }
}
