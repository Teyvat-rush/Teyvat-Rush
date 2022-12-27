using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject bornParent;//敌人生成的父级
  public GameObject EnemyPrefab;//敌人的预制件
  public GameObject SunPrefab;//飘落阳光的预制件
  public float creatEnemyInterval;//生成敌人的间隔时间
  
  public static GameManager instance;
  public int starNum;
  private float BornSuntimer;
  public float BornSunInterval;
    void Start()
    {
    instance = this;
    InvokeRepeating("CreateSunDown", 10, 10);
    BornSuntimer = 0;
    CreateEnemy();
    
    }

    // Update is called once per frame
    void Update()
    {
    BornSuntimer += Time.deltaTime;
    CreatSun();
    }
    public void ChangeStarNum(int ChangeNum)
    {
    starNum += ChangeNum;
        if(starNum<=0)
        {
      starNum = 0;
        }
    }
  public void CreateEnemy()
  {
    StartCoroutine(DalayCreateEnemy());
  }
  //使用携程，隔一段时间在随机一行生成一个敌人
    IEnumerator DalayCreateEnemy()
  {
    //等待
    yield return new WaitForSeconds(creatEnemyInterval);
    //生成
    GameObject enemy = Instantiate(EnemyPrefab);
    int index = Random.Range(0, 5);//生成随机数
    Transform enemyLine = bornParent.transform.Find("Born" + index.ToString());
    enemy.transform.parent = enemyLine;
    enemy.transform.localPosition = Vector3.zero;

    //再次启动计时器
    StartCoroutine(DalayCreateEnemy());
  }
  public void CreatSun()
  {
    if(BornSuntimer>=BornSunInterval)
    {
      BornSuntimer = 0;
      Instantiate(SunPrefab);
      
    }
  }
}
