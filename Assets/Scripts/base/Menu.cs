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
    Time.timeScale = 1f;
    PauseMenu.SetActive(false);
  }
  public void SpeedUp()
  {
    Debug.Log(Time.timeScale);
    if(SpeedText.text.Equals("x1"))
    {
      Time.timeScale = 2f;
      SpeedText.text = "x2";
    }
    if(SpeedText.text.Equals("x2"))
    {
      Time.timeScale = 1f;
      SpeedText.text = "x1";
    }
    
  }
}
