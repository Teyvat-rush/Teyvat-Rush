using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  public static UIManager instance;
  public Text starNumText;
    // Start is called before the first frame update
    void Start()
    {
    instance = this;
    
    }

    // Update is called once per frame
    void Update()
    {
    UIManager.instance.UpdateUI();
    }
  public void InitUI()//初始化UI
  {
   
  }
  public void UpdateUI()//更新UI
  {
    starNumText.text = GameManager.instance.starNum.ToString();
  }
}
