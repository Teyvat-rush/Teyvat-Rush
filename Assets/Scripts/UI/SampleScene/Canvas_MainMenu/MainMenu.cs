using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  int level = 1;
  public GameObject Libraryofenemy;
  public GameObject Libraryofcharacter;
  public GameObject Achievements;
  public GameObject Selecetlevel;
  public GameObject Mainmenu;
    // Start is called before the first frame update
    public void LibraryofEnemy()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(true);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void LibraryofCharcater()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(true);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void OpenAchievements()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(true);
    Selecetlevel.SetActive(false);
  }
  public void OpenSelectLevel()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(true);
  }
  public void QuitGame()
  {
    Application.Quit();
  }
  public void Return()
  {
    Mainmenu.SetActive(true);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void ReturntoCaracter()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(true);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
}
