using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
  public GameObject Failed;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      Failed.SetActive(true);
      SoundManager.instance.StopBGM();
    }
  }

}
