using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using JetBrains.Annotations;
using System.Security.Cryptography.X509Certificates;

public class GameManager : MonoBehaviour
{
    public static GameManagerr gamemanagerr = new GameManagerr();

    public static GameManager instance;
    public List<Sprite> Maps= new List<Sprite>();
    public List<Sprite> rewardImages = new List<Sprite>();//预制体override
    public GameObject button_Reward;//战斗结束奖励按钮
    public List<GameObject> enemies= new List<GameObject>();//预制体override
    // Start is called before the first frame update
    public GameObject bornParent;//敌人生成的父级
    public GameObject EnemyPrefab;//敌人的预制件
    public GameObject SunPrefab;//飘落阳光的预制件
    public GameObject map;
    public GameObject canvas;

    public float creatEnemyInterval;//生成敌人的间隔时间
    //public static int maxCardsNum=6;////////最大卡槽数
    public static int cardsMaxCharacter = 5;/////////////////手动改变
    public static int cardsMaxEnemy = 6;/////////////////手动改变
    public int starNum;
    private float BornSuntimer;
    public float BornSunInterval;
    //[HideInInspector]
    //public LevelData levelData;
    public static bool gameStart = false;//true:已开始作战，无论是否暂停
    public bool gameEnd = false;//true:最后一只怪倒下，无论是否暂停
    //public bool isBattling = false;//true:在关卡内）
    //public int circulateTimes = 1;//当前周目（现在没用到）
    public static int curLevelID = 0;//当前关卡，从0开始数,0-1是第0关
    public static List<string> LevelNames = new List<string>();
    public int curProgressID;//当前波次数，从0开始数
    public int totalDestroyedNum;//总击杀敌人数
    public int waveDestroyedNum;//当前波次击杀敌人数0
    public int waveCreatedNum;//当前波次已生成敌人数
    public static int totalCreatedNum;//总已生成敌人数
    public float MAINTIMER;//主计时器
    public static bool initialize=true;//关卡开始后的初始化
    //public List<GameObject> curProgressEnemy;

    private void Awake()
    {
        Debug.Log("GM awake");
        if(!File.Exists(Application.streamingAssetsPath + "/GameManagerr.json"))
        {
            gamemanagerr.maxCardsNum = 6;
            string json = JsonUtility.ToJson(gamemanagerr, true);
            File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json);
            /////////////各种json变量的初始化
            /////////////各种json变量的初始化
            /////////////各种json变量的初始化
            /////////////各种json变量的初始化
        }
        else
        {
            string json = File.ReadAllText(Application.streamingAssetsPath + "/GameManagerr.json");
            gamemanagerr = JsonUtility.FromJson<GameManagerr>(json);
            curLevelID = gamemanagerr.curLevelID;
            Debug.Log("摩拉数" + gamemanagerr.mora);
            /////////////各种c#变量的赋值
            /////////////各种c#变量的赋值
            /////////////各种c#变量的赋值
            /////////////各种c#变量的赋值
        }
        instance = this;
        gameStart = false;
        gameEnd = false;
        initialize = true;
    }
    void Start()
    {
        //curProgressEnemy = new List<GameObject>();
        //ReadData();
    }
    void Update()
    {
        if(gameStart)
        {
            GameStart();
        }
        if(initialize)//关卡开始后的初始化
        {
            Debug.Log("GM initialize");
            if (Canvas_LibraryOfEnemy.checkMode == 2)
            {
                if (Canvas_Shop.shop.items[0].purchasedState)
                {
                    Debug.Log("买了木桩");
                    for (int i = 0; i < 5; i++)//仅5路地图，待更新
                    {
                        map.transform.GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
                    }
                }else
                {
                    Debug.Log("没买木桩");
                    for (int i = 0; i < 5; i++)//仅5路地图，待更新
                    {
                        map.transform.GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
                    }
                }

                if (curLevelID <= 2)
                {
                    map.GetComponent<SpriteRenderer>().sprite = Maps[curLevelID];
                }else if (curLevelID <= 4)
                {
                    map.GetComponent<SpriteRenderer>().sprite = Maps[2];
                }
            }
            

            
            
            LevelNames.Clear();
            LevelNames.Add("蒙德夜晚 - 1");
            LevelNames.Add("蒙德夜晚 - 2");
            LevelNames.Add("蒙德夜晚 - 3");
            Debug.Log("GameManager:initialize 当前关卡ID"+curLevelID);
            MAINTIMER = 0;
            curProgressID = 0;
            waveCreatedNum= 0;
            waveDestroyedNum = 0;
            waveCreatedNum= 0;
            totalCreatedNum= 0;
            initialize= false;
        }

        
        
    }
    /*
    //void ReadData()
    //{
    //    StartCoroutine(LoadTable());
    //}
    //IEnumerator LoadTable()
    //{
    //    ResourceRequest request = Resources.LoadAsync("Level");
    //    yield return request;
    //    levelData = request.asset as LevelData;
    //    if (gameStart)
    //    {
    //     GameStart();
    //    }
    //}*/
    private void GameStart()
    {
        MAINTIMER += Time.deltaTime;
        CreateEnemy();
        if (!gameEnd)//游戏结束后不掉阳光
        {
            CreatSun();
        }
        //InvokeRepeating("CreateSunDown", 10, 10);
    }
    // Update is called once per frame
    
    public void ChangeStarNum(int ChangeNum)
    {
        starNum += ChangeNum;
        if(starNum<=0)
        {
            starNum = 0;
        }
    }
    //吴用↓
    /*
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

   */
    public void CreatSun()
    {
        BornSuntimer += Time.deltaTime;
        if (BornSuntimer>=BornSunInterval)
        {
            BornSuntimer = 0;
            Instantiate(SunPrefab);
        }
    }

    public void CreateEnemy()
    {
        if (totalCreatedNum < LevelData.totalNums[curLevelID]) 
        {
            if (MAINTIMER > LevelData.Levels[curLevelID][totalCreatedNum].CreateTime)
            {
                Debug.Log("生成敌人");
                //生成实例
                GameObject Enemy = Instantiate(enemies[LevelData.Levels[curLevelID][totalCreatedNum].EnemyType]);
                //根据配表的生成位置，找到父物体
                //Transform EnemyLine = bornParent.transform.Find("Born" + Random.Range(0, 6).ToString());
                List<int> ran_n = new List<int>();
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran0 == 1)
                {
                    ran_n.Add(0);
                }
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran1 == 1)
                {
                    ran_n.Add(1);
                }
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran2 == 1)
                {
                    ran_n.Add(2);
                }
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran3 == 1)
                {
                    ran_n.Add(3);
                }
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran4 == 1)
                {
                    ran_n.Add(4);
                }
                if (LevelData.Levels[curLevelID][totalCreatedNum].Ran5 == 1)
                {
                    ran_n.Add(5);
                }
                int n = Random.Range(0, ran_n.Count);
                Transform EnemyLine = bornParent.transform.Find("Born" + ran_n[n].ToString());
                //Debug.Log("生成行序号" + ran_n + "在第" + ran_n[n] + "行生成");
                Enemy.transform.parent = EnemyLine;
                Enemy.transform.localPosition = new Vector3(0,0,-totalCreatedNum-1);
                if (LevelData.Levels[curLevelID][totalCreatedNum].EnemyType == 0)
                {
                    Enemy.transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y - 0.8f, -totalCreatedNum-1);
                }
                waveCreatedNum++;
                totalCreatedNum++;
            }
        }
        
    }

    public void EnemyDied(GameObject f_gameObject)
    {
        /*
    //if(curProgressEnemy.Contains(gameObject))
    //{
      //curProgressEnemy.Remove(gameObject);
    //}
    //当前波次的全部敌人都被消灭了，开启下一个波次
    //if(curProgressEnemy.Count==0)
    //{
    //  curProgressID += 1;
     // CreateEnemy();
    //}
        */
        waveDestroyedNum++;
        totalDestroyedNum++;
        if(waveDestroyedNum == LevelData.Levels[curLevelID][totalDestroyedNum - 1].TimeID_max)//这波次鲨完了
        {
            if (curProgressID < LevelData.Levels[curLevelID][0].ProgressID_max)
            {
                Debug.Log("Next Wave");
                ProgressBar.Flags[curProgressID].transform.position = new Vector3(ProgressBar.Flags[curProgressID].transform.position.x, ProgressBar.Flags[curProgressID].transform.position.y + 0.21f, ProgressBar.Flags[curProgressID].transform.position.z);
                curProgressID += 1;
                MAINTIMER = LevelData.Levels[curLevelID][totalDestroyedNum].CreateTime - 3f;
                waveDestroyedNum = 0;
                waveCreatedNum = 0;
            }
            else
            {
                GameObject rewardHere= Instantiate(button_Reward,f_gameObject.transform.position,f_gameObject.transform.rotation, canvas.transform);
                rewardHere.SetActive(true);
                rewardHere.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = rewardImages[curLevelID];
                rewardHere.GetComponent<Animator>().SetBool("IsOK", true);
                gameStart = false;
                gameEnd = true;
                //initialize = true;
                Canvas_LibraryOfEnemy.checkMode = 1;
            }
        }
    }
}
