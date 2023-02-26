using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Menu : MonoBehaviour
{
    public static bool isInBattle;//在地图界面，防止在看图鉴等情况时按到了Esc
  public bool isPause;
  public GameObject PauseMenu;
    public GameObject panel_ConfirmExit_Extended;
  public Text SpeedText;
  public GameObject Achievements;
  public GameObject Characters_Library;
  public GameObject Enemies_Library;
  public AudioMixer audioMixer_Music;
  public AudioMixer audioMixer_MusicEffect;
     void Start()
     {
        isPause = false;
        isInBattle = false;
        Time.timeScale = 1f;
     }
    void Update()
    {
        if (GameManager.gameStart && isInBattle)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPause)
                {
                    pauseGame();
                }
                else
                {
                    resumeGame();
                }
            }
            if(!isPause)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SpeedText.text = "x1";
                    Time.timeScale = 1f;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SpeedText.text = "x2";
                    Time.timeScale = 2f;
                }
            }
            
        }

    }
    public void pauseGame()
    {
        SoundManager.instance.PlaySound(Globals.Open2);
        isPause = true;
        Time.timeScale = 0f;
     PauseMenu.SetActive(true);
     }
    public void Open_Characters_Library()
    {
        isInBattle = false;
        Canvas_LibraryOfCharacter.initialize = true;
        Characters_Library.SetActive(true);
        Enemies_Library.SetActive(false);
    }
    public void Open_Enemies_Library()
    {
        SoundManager.instance.PlaySound(Globals.Open1);
        isInBattle = false;
        Characters_Library.SetActive(false);
        Enemies_Library.SetActive(true);
    }
    public void Open_Achievements()
    {
        SoundManager.instance.PlaySound(Globals.Open1);
        isInBattle = false;
        Achievements.SetActive(true);
        Canvas_Achievement.initialize= true;
    }
    public void Close_Library()
    {
        isInBattle = true;
        Characters_Library.SetActive(false);
        Enemies_Library.SetActive(false);
    }
    public void resumeGame()
    {
        SoundManager.instance.PlaySound(Globals.Return0);
        isPause = false;
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
        if(Canvas_LibraryOfEnemy.checkMode == 2)
        {
            panel_ConfirmExit_Extended.SetActive(true);
        }
        else
        {
            isInBattle = false;
            SoundManager.instance.PlaySound(Globals.Return1);
            Canvas_LibraryOfEnemy.checkMode = 1;
            SceneManager.LoadScene(0);
        }
        
    }
    public void Restart()
    {
        isInBattle = false;
        // CardSlot.initialize=true;
        //Canvas_LibraryOfCharacter.initialize=true;
        GameManager.initialize = true;
        Canvas_LibraryOfEnemy.checkMode = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetMusicVolume(float value)
    {
        audioMixer_Music.SetFloat("MusicVolume", value);
    }
    public void SetMusicEffectVolume(float value)
    {
        audioMixer_MusicEffect.SetFloat("MusicEffectVolume", value);
    }

    public void ConfirmExit()
    {
        isInBattle = false;
        SoundManager.instance.PlaySound(Globals.Return1);
        Canvas_LibraryOfEnemy.checkMode = 1;
        SceneManager.LoadScene(0);
    }
    public void CancelExit()
    {
        panel_ConfirmExit_Extended.SetActive(false);
    }
}
