using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
  private Rigidbody2D rb;
  public float Speed;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    Movement();
    SwitchAnim();
    }
  void Movement()
  {
      rb.velocity = new Vector2(-Speed, 0);
  }
  void SwitchAnim()
  {
    void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag=="Plants")
      {
        rb.velocity = new Vector2(0, 0);
      }
  }
  }
  
}
