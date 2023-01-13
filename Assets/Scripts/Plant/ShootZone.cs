using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootZone : MonoBehaviour
{
  public GameObject Parent;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      Parent.GetComponent<Plant>().ShootAwake = true;
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      Parent.GetComponent<Plant>().ShootAwake = false;
    }
  }
}
