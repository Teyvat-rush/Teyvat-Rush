using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
  public Vector3 Direction;
  public float Speed;
  public float damage;
  void Start()
  {
    GameObject.Destroy(gameObject, 8);
  }

  void Update()
  {
    transform.position += Direction * Speed * Time.deltaTime;
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      //销毁子弹
      GameObject.Destroy(gameObject);
      //僵尸受击
      collision.GetComponent<Enemy>().ChangeHealth(-damage);
    }
  }
}
