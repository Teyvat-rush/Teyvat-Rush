using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
  public GameObject PauseMenu;
  public Text SpeedText;
     void Start()
    {
        Time.timeScale = 1f;
    }
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
  public void ReturntoMenu()
  {
    SceneManager.LoadScene(0);
  }
 public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
