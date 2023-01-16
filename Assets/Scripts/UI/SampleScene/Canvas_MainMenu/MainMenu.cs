using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //int level = 1;
    public Text startLevelName;
  public GameObject Libraryofenemy;
  public GameObject Libraryofcharacter;
  public GameObject Achievements;
  public GameObject Selecetlevel;
    public GameObject Shop;
  public GameObject Mainmenu;
    public static bool initialize = true;


    public void Awake()
    {
        GameManager.initialize = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void LibraryofEnemy()
  {
        Canvas_LibraryOfEnemy.checkMode = 1;
        Canvas_LibraryOfEnemy.initialize = true;
        Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(true);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void LibraryofCharcater()
  {
        Canvas_LibraryOfCharacter.initialize = true;
        Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(true);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void OpenAchievements()
  {
    Canvas_Achievement.initialize = true;
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(true);
    Selecetlevel.SetActive(false);
  }
  //public void OpenSelectLevel()
  //{
  //  Mainmenu.SetActive(false);
  //  Libraryofcharacter.SetActive(false);
  //  Libraryofenemy.SetActive(false);
  //  Achievements.SetActive(false);
  //  Selecetlevel.SetActive(true);
  //}
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
  public void ReturntoCharacter()
  {
    Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(true);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }

    public void OpenShop()
    {
        Mainmenu.SetActive(false);
        Shop.SetActive(true);
    }

    void Update()
    {
        startLevelName.text = GameManager.LevelNames[GameManager.curLevelID];

       if(initialize)
        {
            Canvas_LibraryOfEnemy.checkMode = 1;
            initialize =false;
            ///////成就初始化
        }
    }
}
