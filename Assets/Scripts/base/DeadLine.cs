using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeadLine : MonoBehaviour
{
  public GameObject panel_Failed;
    public GameObject image_Enemy;
  public Text Enemy_Name;
    private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag=="Enemy")
    {
    Time.timeScale = 1f;
    panel_Failed.SetActive(true);
      SoundManager.instance.StopBGM();
      image_Enemy.GetComponent<Image>().sprite= LibraryOfEnemy.instance.ALLImages[collision.GetComponent<Enemy>().Enemyid];
      Enemy_Name.text = LibraryOfEnemy.ALLEnemies[collision.GetComponent<Enemy>().Enemyid].characterName;
            //if(collision.gameObject.name=="qqRen")
            //image_Enemy = LibraryOfEnemy.instance.ALLImages[2];
    }
  }

}
