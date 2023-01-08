using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
  public float Speed;
  public GameObject slime;
  private Animator animator;
  private Rigidbody2D rigidbody2D;
  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
    animator = slime.GetComponent<Animator>();
    rigidbody2D = slime.GetComponent<Rigidbody2D>();
    rb = GetComponent<Rigidbody2D>();
    boxCollider = slime.GetComponent<BoxCollider2D>();
    animator.SetBool("Jump", true);
    }

    // Update is called once per frame
    void Update()
    {
    if(animator.GetBool("Jump"))
    {
      Movement();
    }
    }
  void Movement()
  {
    rb.velocity = new Vector2(-Speed, rb.velocity.y);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag=="Plant")
    {
      animator.SetBool("Jump", false);
      animator.SetBool("Attack", true);
      PauseMove();
    }
  }
  public void PauseMove()
  {
    Speed = 0;
  }
  public void ContinueMove()
  {
    Speed = 0.8f;
  }
}
