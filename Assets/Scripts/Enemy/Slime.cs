using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
  private float timer;
  public float Speed;
  public GameObject slime;
  private Animator animator;
  private Rigidbody2D rigidbody2D;
  private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
    animator = slime.GetComponent<Animator>();
    rigidbody2D = slime.GetComponent<Rigidbody2D>();
    boxCollider = slime.GetComponent<BoxCollider2D>();
    animator.SetBool("Jump", true);
    }

    // Update is called once per frame
    void Update()
    {
    timer += Time.deltaTime;
    if(animator.GetBool("Jump"))
    {
      Movement();
    }
    }
  void Movement()
  {
    rigidbody2D.velocity = new Vector2(-Speed, rigidbody2D.velocity.y);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag=="Plant")
    {
      animator.SetBool("Jump", false);
      animator.SetBool("Attack", true);
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
