using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedUp : MonoBehaviour
{
  private bool flag;
  public Text SpeedText;
  private void Start()
  {
    flag = false;
  }
  public void Onclick()
  {
    if(!flag)
    {
      Time.timeScale = 2f;
      SpeedText.text = "x2";
      flag = true;
    }
    else
    {
      Time.timeScale = 1f;
      SpeedText.text = "x1";
      flag = false;
    }
  }
}
