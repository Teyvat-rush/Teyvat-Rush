using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseLevel : MonoBehaviour
{
    public GameObject canvasSelectLevel;
  public void OpenCanvasSelectLevel()
  {
    canvasSelectLevel.SetActive(true);
    //gameObject.SetActive(false);
  }

}
