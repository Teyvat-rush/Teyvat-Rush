using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour
{
  public GameObject darkBG;//星辉不足时的背景
  public GameObject Progress;//进度条
  public float WaitTime;//等待时间
  public int UseStar;//消耗的星辉
  private float timer;//计时器
    // Start is called before the first frame update
    void Start()
    {//另一种获取物体的方式：获取子物体
    darkBG = transform.Find("DarkBg").gameObject;
    Progress = transform.Find("Progress").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDarkBG();
    }
  void UpdateProgress()
  {//更新进度条
    float per = Mathf.Clamp(timer/WaitTime,0,1);
    Progress.GetComponent<Image>().fillAmount = 1 - per;
  }
  void UpdateDarkBG()
  {
    if(Progress.GetComponent<Image>().fillAmount==0)
    {
      darkBG.SetActive(false);
    }
    else
    {
      darkBG.SetActive(true);
    }
  }
  //拖拽开始（鼠标点下的一瞬间）
  public void onBeginDrag(BaseEventData data)
  {

  }
  //拖拽过程（鼠标按着没放开）
  public void OnDrag(BaseEventData data)
  {

  }
  //拖拽结束（鼠标放开的一瞬间）
  public void OnEndDrag(BaseEventData data)
  {

  }
}
