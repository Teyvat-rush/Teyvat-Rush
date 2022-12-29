using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coin
{
  public int num;
}

public class GameManager : MonoBehaviour
{
  public Coin coin = new Coin();
  // Start is called before the first frame update
  public GameObject bornParent;//敌人生成的父级
  public GameObject EnemyPrefab;//敌人的预制件
  public GameObject SunPrefab;//飘落阳光的预制件
  public float creatEnemyInterval;//生成敌人的间隔时间
  
  public static GameManager instance;
  public int starNum;
  private float BornSuntimer;
  public float BornSunInterval;
  [HideInInspector]
  public LevelData levelData;
  public bool gameStart;
  public int curLevelID = 1;//当前关卡
  public int curProgressID = 1;//当前波次
  public List<GameObject> curProgressEnemy;
  private void Awake()
  {
    instance = this;
  }
  void Start()
    {
    curProgressEnemy = new List<GameObject>();
    ReadData();
    
    
    }
  void ReadData()
  {
    StartCoroutine(LoadTable());
  }
  IEnumerator LoadTable()
  {
    ResourceRequest request = Resources.LoadAsync("Level");
    yield return request;
    levelData = request.asset as LevelData;
    GameStart();
  }
  private void GameStart()
  {
    CreateEnemy();
    InvokeRepeating("CreateSunDown", 10, 10);

    gameStart = true;
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
  private void TableCreateEnemy()
  {
    //判断是否为最后一波并且敌人全部创建出来
    bool canCreate = false;
    for(int i=0;i<levelData.LevelDataList.Count;i++)
    {
      LevelItem levelItem = levelData.LevelDataList[i];
      //属于当前关卡的敌人
      if (levelItem.LevelID == curLevelID && levelItem.ProgressID == curProgressID) 
      {
        StartCoroutine(ITableCreateEnemy(levelItem));
        //代表当前波次有敌人
        canCreate = true;
      }
    }
    if(!canCreate)
    {
      StopAllCoroutines();
      curProgressEnemy = new List<GameObject>();
      //TODO获胜
      gameStart = false;
    }
  }
  IEnumerator ITableCreateEnemy(LevelItem levelItem)
  {
    yield return new WaitForSeconds(levelItem.CreateTime);
    //加载预制件，从Resources文件夹中加载

      GameObject EnemyPrefab = Resources.Load("Prefabs/qqRen0") as GameObject;


      //生成实例
      GameObject Enemy = Instantiate(EnemyPrefab);
    //根据配表的生成位置，找到父物体
    Transform EnemyLine = bornParent.transform.Find("Born" + Random.Range(0, 6).ToString());
    Enemy.transform.parent = EnemyLine;
    Enemy.transform.localPosition = Vector3.zero;
    curProgressEnemy.Add(Enemy);
  }
  public void CreateEnemy()
  {
    //StartCoroutine(DalayCreateEnemy());
    TableCreateEnemy();
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
  public void EnemyDied(GameObject gameObject)
  {
    if(curProgressEnemy.Contains(gameObject))
    {
      curProgressEnemy.Remove(gameObject);
    }
    //当前波次的全部敌人都被消灭了，开启下一个波次
    if(curProgressEnemy.Count==0)
    {
      curProgressID += 1;
      TableCreateEnemy();
    }
  }
}
