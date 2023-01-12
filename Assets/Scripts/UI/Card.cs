using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour
{
  public GameObject objectPrefab;//卡片对应的预制件
  private GameObject curGameObject;//记录当前创建出来的物体
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
    if(Progress.GetComponent<Image>().fillAmount==0&&GameManager.instance.starNum>=UseStar)
    {
      darkBG.SetActive(false);
    }
    else
    {
      darkBG.SetActive(true);
    }
  }
  //拖拽开始（鼠标点下的一瞬间）
  public void OnBeginDrag(BaseEventData data)
  {
    if(darkBG.activeSelf)
    {
      return;
    }
    PointerEventData pointerEventData = data as PointerEventData;
    curGameObject = Instantiate(objectPrefab);
    curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    
  }
  //拖拽过程（鼠标按着没放开）
  public void OnDrag(BaseEventData data)
  {
    if(curGameObject==null)
    {
      return;
    }
    PointerEventData pointerEventData = data as PointerEventData;
    //根据鼠标移动的位置移动物体
    curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    
    print(Input.mousePosition);
  }
  //拖拽结束（鼠标放开的一瞬间）
  public void OnEndDrag(BaseEventData data)
  {
    if(curGameObject==null) return;
    PointerEventData pointerEventData = data as PointerEventData;
    //拿到鼠标所在位置的所有碰撞体
    Collider2D[] col = Physics2D.OverlapPointAll(TranslateScreenToWorld(pointerEventData.position));
    //遍历碰撞体
    foreach(Collider2D c in col)
    {
      //判断物体的标签为土地，并且地上还不存在植物
      if(c.tag == "Land"&&c.transform.childCount==0)
      {
        //把当前物体设置为土地的子物体
        curGameObject.transform.parent = c.transform;
        curGameObject.transform.localPosition = Vector3.zero;
        if(objectPrefab.name== "Point_Wendi")
        {
          int i = Random.Range(1, 4);
          SoundManager.instance.PlaySound(Globals.WendiPlanted+i.ToString());
        }
        if (objectPrefab.name == "Point_Mona")
        {
          int i = Random.Range(1, 4);
          SoundManager.instance.PlaySound(Globals.MonaPlanted + i.ToString());
        }
        if (objectPrefab.name == "Point_Nuoaier")
        {
          int i = Random.Range(1, 4);
          SoundManager.instance.PlaySound(Globals.NuoaierPlanted + i.ToString());
        }
        //重置
        curGameObject.GetComponent<Plant>().PlantAwake = true;
        curGameObject = null;
        GameManager.instance.ChangeStarNum(-UseStar);
        timer = 0;
        break;
      }
    }
    //如果没有碰到土地，就销毁他
    if(curGameObject!=null)
    {
      GameObject.Destroy(curGameObject);
      curGameObject = null;
    }
  }
  public static Vector3 TranslateScreenToWorld(Vector3 position)
  {
    Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
    return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
  }
}
