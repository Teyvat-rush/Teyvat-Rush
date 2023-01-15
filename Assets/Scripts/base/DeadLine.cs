using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
  public GameObject panel_Failed;
    public Sprite image_Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
      panel_Failed.SetActive(true);
      SoundManager.instance.StopBGM();
            if(collision.gameObject.name=="qqRen")
            image_Enemy = LibraryOfEnemy.instance.ALLImages[2];
    }
  }

}
