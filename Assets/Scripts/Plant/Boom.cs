using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
  // Start is called before the first frame update
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      collision.GetComponent<Enemy>().ChangeHealth(-600f);
    }
  }
}
