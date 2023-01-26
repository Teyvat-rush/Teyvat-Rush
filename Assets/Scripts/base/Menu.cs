using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Menu : MonoBehaviour
{
  public bool isPause;
  public GameObject PauseMenu;
  public Text SpeedText;
  public GameObject Achievements;
  public GameObject Characters_Library;
  public GameObject Enemies_Library;
  public AudioMixer audioMixer_Music;
  public AudioMixer audioMixer_MusicEffect;
     void Start()
    {
    isPause = false;
        Time.timeScale = 1f;
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
    Characters_Library.SetActive(true);
    Enemies_Library.SetActive(false);
  }
  public void Open_Enemies_Library()
  {
    Characters_Library.SetActive(false);
    Enemies_Library.SetActive(true);
  }
  public void Close_Library()
  {
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
        SoundManager.instance.PlaySound(Globals.Return1);
        Canvas_LibraryOfEnemy.checkMode = 1;
    SceneManager.LoadScene(0);
  }
 public void Restart()
  {
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
}
