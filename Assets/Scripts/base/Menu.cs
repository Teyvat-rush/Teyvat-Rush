using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
  public GameObject PauseMenu;
  
  public void pauseGame()
  {
    Time.timeScale = 0f;
    PauseMenu.SetActive(true);
  }
  public void resumeGame()
  {
    Time.timeScale = 1f;
    PauseMenu.SetActive(false);
  }
 
}
