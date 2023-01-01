using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
  public GameObject PauseMenu;
  public Text SpeedText;
  public void pauseGame()
  {
    Time.timeScale = 0f;
    PauseMenu.SetActive(true);
  }
  public void resumeGame()
  {
    if(SpeedText.text.Equals("x1"))
    {
      Time.timeScale = 1f;
    }
    else
    {
      Time.timeScale = 2f;
    }
    PauseMenu.SetActive(false);
  }
 
}
