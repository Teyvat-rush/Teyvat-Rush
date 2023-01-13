using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Canvas_LibraryOfCharacter : MonoBehaviour
{
    //public static Canvas_LibraryOfCharacter instance;
    public GameObject panel_Cards;
    public List<GameObject> attainedCards;
    public List<Button> attainedCardsButtons;
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
    //public int attainedCardsNum;
    //public static int checkMode = 1;//1�����˵�ͼ����2��ѡ����ؿ��ڴ�ͼ��
    public static bool initialize = true;
    public int lastChosenIndex = 0;//Ĭ��ѡ��һ��
    // Start is called before the first frame update
    void Start()
    {
        initialize = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initialize)
        {
            Debug.Log("Canvas_LibraryOfCharacter:initialize");
            lastChosenIndex = 0;
            button_Close_FriendshipLevelReward.GetComponent<Button>().onClick.AddListener(CloseFriendshipLevelReward);
            button_FriendshipLevelReward.GetComponent<Button>().onClick.AddListener(OpenFriendshipLevelReward);
            //attainedCardsNum = 2;////////////////////////////////��ȡ�ؿ����ȣ��ı�ӵ�н�ɫ��(����GameManager�д洢)
            for (int i = 0; i < GameManager.instance.attainedCardsNum; i++)
            {
                attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
                attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());
                attainedCards[i].GetComponent<EventTrigger>().enabled = false;
                int temp_1 = i;
                attainedCardsButtons[i].onClick.RemoveAllListeners();
                attainedCardsButtons[i].onClick.AddListener(delegate { OpenPanelDetail(temp_1); });//ÿһ����ť���Ӽ����¼��������ݲ�����temp_1ͼ����ţ�̫nice�ˣ�������
            }
            attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;
            OpenPanelDetail(lastChosenIndex);
            
            for(int i=1;i< GameManager.instance.attainedCardsNum; i++)
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
        Debug.Log("�򿪵�" + index + "����ɫ����");
        characterName.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].characterName;
        description.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].description;
        image.GetComponent<Image>().sprite = LibraryOfCharacter.ALLCharacters[index].image;
        HPLevel.GetComponent<Text>().text= LibraryOfCharacter.ALLCharacters[index].HPLevel;     
        ATKLevel.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].ATKLevel;
        ATKorSkillInterval.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].ATKorSkillInterval;
        reloadTimeLevel.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].reloadTimeLevel;
        Debug.Log("���µ�"+index+"��ɫ�øж�");
        friendshipEXP.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipEXP.ToString();
        friendshipEXPMAX.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipEXPMAX.ToString();
        friendshipLevelNum.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelNum.ToString();
        friendshipLevelRewardTitle.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelRewardTitle;
        friendshipLevelReward.GetComponent<Text>().text = LibraryOfCharacter.ALLCharacters[index].friendshipLevelReward;

        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = true;
        lastChosenIndex = index;
        attainedCards[lastChosenIndex].GetComponent<Button>().interactable = false;//��ѡ�еĲ�����ѡ
    }
}
