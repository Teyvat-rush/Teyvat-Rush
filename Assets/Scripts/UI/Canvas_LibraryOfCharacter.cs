using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Canvas_LibraryOfCharacter : MonoBehaviour
{
    public GameObject panel_Cards;
    public List<GameObject> attainedCards=new List<GameObject>();
    public List<Button> attainedCardsButtons=new List<Button>();
    public GameObject panel_FriendshipLevelReward;
    public GameObject button_Close_FriendshipLevelReward;
    public GameObject button_FriendshipLevelReward;
    public GameObject characterName;
    public GameObject description;
    public GameObject image;
    public GameObject HPLevel;
    public GameObject ATKLevel;
    public GameObject ATKorSkillInterval;
    public GameObject reloadTimeLevel;
    public GameObject friendshipEXP;
    public GameObject friendshipEXPMAX;
    public GameObject friendshipLevelNum;
    public GameObject friendshipLevelRewardTitle;
    public GameObject friendshipLevelReward;
    public GameObject slider_FriendshipProgress;
    //public static int checkMode = 1;//1：主菜单图鉴；2：选卡或关卡内打开图鉴
    public static List<int> attainedNumPerLevel=new List<int>();//每关拥有的角色卡数
    public static bool initialize = false;
    public int lastChosenIndex = 0;//默认选第一个
    // Start is called before the first frame update
    void Awake()
    {
        initialize = true;
        Debug.Log("Canvas_LibraryOfCharacter:Awake");
        attainedNumPerLevel.Clear();
        attainedNumPerLevel.Add(1);
        attainedNumPerLevel.Add(2);
        attainedNumPerLevel.Add(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (initialize)
        {
            Debug.Log("Canvas_LibraryOfCharacter:initialize");
            button_Close_FriendshipLevelReward.GetComponent<Button>().onClick.RemoveAllListeners();
            button_Close_FriendshipLevelReward.GetComponent<Button>().onClick.AddListener(CloseFriendshipLevelReward);
            button_FriendshipLevelReward.GetComponent<Button>().onClick.RemoveAllListeners();
            button_FriendshipLevelReward.GetComponent<Button>().onClick.AddListener(OpenFriendshipLevelReward);
            attainedCards.Clear();
            attainedCardsButtons.Clear();
            for (int i= 0;i<GameManager.cardsMaxCharacter;i++)//获取所有角色卡
            {
                //Debug.Log("Canvas_LibraryOfCharacter:加入第"+i+"张卡");
                
                
                attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
                
                attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());
                attainedCards[i].GetComponent<EventTrigger>().enabled = false;
                int temp_1 = i;
                attainedCardsButtons[i].onClick.RemoveAllListeners();
                attainedCardsButtons[i].onClick.AddListener(delegate { OpenPanelDetail(temp_1); });//每一个按钮增加监听事件，并传递参数，temp_1图鉴序号（太nice了！！！）
                attainedCards[i].SetActive(false);
            }
            for (int i = 0; i < attainedNumPerLevel[GameManager.curLevelID]; i++)//只显示获得的角色卡
            {
                attainedCards[i].SetActive(true);
            }
            lastChosenIndex = 0;
            attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;
            OpenPanelDetail(lastChosenIndex);
            for(int i=1;i< attainedNumPerLevel[GameManager.curLevelID]; i++)
            {
                attainedCards[i].GetComponent<Button>().interactable = true;
            }
            initialize = false;
        }
    }
    public void CloseFriendshipLevelReward()
    {
        panel_FriendshipLevelReward.SetActive(false);
    }
    public void OpenFriendshipLevelReward()
    {
        panel_FriendshipLevelReward.SetActive(true);
    }
    public void OpenPanelDetail(int index)
    {
        Debug.Log("打开（更新）第" + index + "个角色详情");
        characterName.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].characterName;
        description.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].description;
        image.GetComponent<Image>().sprite = LibraryOfCharacter.ALLCharacters[index].image;
        HPLevel.GetComponent<Text>().text= LibraryOfCharacter.ALLCharacters[index].HPLevel;     
        ATKLevel.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].ATKLevel;
        ATKorSkillInterval.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].ATKorSkillInterval;
        reloadTimeLevel.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].reloadTimeLevel;
        //Debug.Log("更新第"+index+"角色好感度");
        friendshipEXP.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipEXP.ToString();
        friendshipEXPMAX.GetComponent<Text>().text = LibraryOfCharacter.friendshipEXPMAXs[LibraryOfCharacter.ALLCharacters[index].friendshipLevelNum].ToString();
        friendshipLevelNum.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelNum.ToString();
        friendshipLevelRewardTitle.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelRewardTitle;
        friendshipLevelReward.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelReward;
        slider_FriendshipProgress.GetComponent<Slider>().value = (float)LibraryOfCharacter.ALLCharacters[index].friendshipEXP/ (float)LibraryOfCharacter.friendshipEXPMAXs[LibraryOfCharacter.ALLCharacters[index].friendshipLevelNum];
        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = true;
        lastChosenIndex = index;
        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;//被选中的不能再选
    }
}
