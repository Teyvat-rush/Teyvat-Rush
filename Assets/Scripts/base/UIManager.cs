using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  public static UIManager instance;
  public Slider slider;
  public Text starNumText;
  public Text MoraText;
  public float timer;
    // Start is called before the first frame update
    void Start()
    {
    timer = 0;
    instance = this;
    slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
    UIManager.instance.UpdateUI();
    timer += Time.deltaTime;
    if (timer >= 10)
    {
      slider.value += Time.deltaTime / 20;
    }
  }
  public void InitUI()//初始化UI
  {
   
  }
  public void UpdateUI()//更新UI
  {
    starNumText.text = GameManager.instance.starNum.ToString();
    MoraText.text = DataManager.instance.coin.num.ToString();
  }
  public Vector3 GetSunNumTextPos()
  {
    return starNumText.transform.position;//得到阳光的屏幕坐标
  }
  public Vector3 GetMoraNumTextPos()
  {
    return MoraText.transform.position;
  }
}
