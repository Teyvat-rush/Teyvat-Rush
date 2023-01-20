using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Canvas_LibraryOfEnemy : MonoBehaviour
{
    //public static Canvas_LibraryOfEnemy instance;

    public GameObject panel_Cards;
    public GameObject text_LibraryOfEnemy;
    public GameObject text_EnemyReview;
    public GameObject text_SelectCard;
    public GameObject text_Return;
    public List<GameObject> attainedCards;
    public List<Button> attainedCardsButtons;


    public GameObject characterName;
    public GameObject description;
    public GameObject image;
    public GameObject HPLevel;
    public GameObject ATKLevel;
    public GameObject ATKIntervalLevel;
    public GameObject MoveVelocityLevel;
    public static int checkMode;//1：主菜单或关卡结束图鉴；2：选卡或关卡未结束内打开图鉴
    public static List<int> attainedNumPerLevel = new List<int>();//每关拥有的敌人卡数
    public static bool initialize = false;
    public int lastChosenIndex=0;//默认选第一个
    // Start is called before the first frame update
    void Awake()
    {
        initialize = true;
        Debug.Log("Canvas_LibraryOfEnemy:Awake");
        attainedNumPerLevel.Clear();
        attainedNumPerLevel.Add(6);
        attainedNumPerLevel.Add(6);
        attainedNumPerLevel.Add(6);
    }

    // Update is called once per frame
    void Update()
    {
        if(initialize)//只调用一次
        {
            Debug.Log(checkMode);
            Debug.Log("Canvas_LibraryOfEnemy:initialize");
            if (checkMode==1)//不在关卡中
            {
                text_LibraryOfEnemy.SetActive(true);
                text_EnemyReview.SetActive(false);
                text_Return.GetComponent<Text>().text = "主 菜 单";
                text_SelectCard.GetComponent<Text>().text = "点击查看遇到过的敌人！";
                attainedCards.Clear();
                attainedCardsButtons.Clear();
                for (int i = 0; i < GameManager.cardsMaxEnemy; i++)
                {
                    attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
                    attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());
                    attainedCards[i].GetComponent<EventTrigger>().enabled = false;
                    int temp_1 = i;
                    attainedCardsButtons[i].onClick.RemoveAllListeners();
                    attainedCardsButtons[i].onClick.AddListener(delegate { OpenPanelDetail(temp_1); });//每一个按钮增加监听事件，并传递参数，temp_1图鉴序号（太nice了！！！）
                    attainedCards[i].SetActive(true);
                }
                attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;
            }else
            {
                text_LibraryOfEnemy.SetActive(false);
                text_EnemyReview.SetActive(true);
                text_Return.GetComponent<Text>().text = "返 回 关 卡";
                text_SelectCard.GetComponent<Text>().text = "点击查看本关出现的敌人！";
                attainedCards.Clear();
                attainedCardsButtons.Clear();
                for (int i = 0; i < GameManager.cardsMaxEnemy; i++)
                {
                    attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
                    attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());
                    attainedCards[i].GetComponent<EventTrigger>().enabled = false;
                    int temp_1 = i;
                    attainedCardsButtons[i].onClick.RemoveAllListeners();
                    attainedCardsButtons[i].onClick.AddListener(delegate { OpenPanelDetail(temp_1); });//每一个按钮增加监听事件，并传递参数，temp_1图鉴序号（太nice了！！！）
                    attainedCards[i].SetActive(false);
                    
                }
                for(int i=0;i< LevelData.totalNums[GameManager.curLevelID];i++)//对于这关出现的每一个敌人
                {
                    attainedCards[LevelData.Levels[GameManager.curLevelID][i].EnemyType].SetActive(true);
                }
                attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;
            }
            initialize= false;
        }
    }
    public void OpenPanelDetail(int index)
    {
        Debug.Log("打开第" + index + "个敌人详情");
        SoundManager.instance.PlaySound(Globals.Open1);
        characterName.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].characterName;
        description.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].description;
        image.GetComponent<Image>().sprite = LibraryOfEnemy.ALLEnemies[index].image;
        HPLevel.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].HPLevel;
        ATKLevel.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].ATKLevel;
        ATKIntervalLevel.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].ATKIntervalLevel;
        MoveVelocityLevel.GetComponent<Text>().text = LibraryOfEnemy.ALLEnemies[index].MoveVelocityLevel;
        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = true;
        lastChosenIndex= index;
        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;//被选中的不能再选
    }
}