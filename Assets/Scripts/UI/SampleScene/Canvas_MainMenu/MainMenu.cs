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
    public GameObject buuton_Start;
    public static bool initialize = true;
    public float startTimer = 0;
    public bool canStart = false;
    public bool isInLibrary = false;
    public void Awake()
    {
        GameManager.initialize = true;
    }
    public void StartGame()
    {
        SoundManager.instance.PlaySound(Globals.StartGame);
        canStart= true;
        buuton_Start.GetComponent<Button>().interactable = false;
    }


    public void LibraryofEnemy()
  {
        if (!isInLibrary)
        {
            SoundManager.instance.PlaySound(Globals.Open0);
        }
        else
        {
            SoundManager.instance.PlaySound(Globals.Open1);
        }
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
        if(!isInLibrary)
        {
            SoundManager.instance.PlaySound(Globals.Open0);
        }else
        {
            SoundManager.instance.PlaySound(Globals.Open1);
        }
        isInLibrary = true;
        Canvas_LibraryOfCharacter.initialize = true;
        Mainmenu.SetActive(false);
    Libraryofcharacter.SetActive(true);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  public void OpenAchievements()
  {
        SoundManager.instance.PlaySound(Globals.Open2);

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
        SoundManager.instance.PlaySound(Globals.Return1);

        isInLibrary = false;
        Mainmenu.SetActive(true);
    Libraryofcharacter.SetActive(false);
    Libraryofenemy.SetActive(false);
    Achievements.SetActive(false);
    Selecetlevel.SetActive(false);
  }
  //public void ReturntoCharacter()
  //{
  //  Mainmenu.SetActive(false);
  //  Libraryofcharacter.SetActive(true);
  //  Libraryofenemy.SetActive(false);
  //  Achievements.SetActive(false);
  //  Selecetlevel.SetActive(false);
  //}

    public void OpenShop()
    {
        SoundManager.instance.PlaySound(Globals.Open3);
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

        if(canStart)
        {
            startTimer += Time.deltaTime;
            if (startTimer > 2.8f)
            {
                startTimer = 0;
                canStart=false;
                Canvas_LibraryOfEnemy.checkMode = 2;
                
                SceneManager.LoadScene(1);
            }
        }
    }
}
