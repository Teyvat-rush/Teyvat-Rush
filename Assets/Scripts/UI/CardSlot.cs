using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public GameObject panel_SelectCard;//ѡ����
    public GameObject panel_Cards;//���н�ɫ����һ��������
    public GameObject button_Start;//��ʼ��ť
    public GameObject button_Menu;//���˵���ť
    public GameObject button_TimeSpeed;//���ٰ�ť
    public GameObject button_Pause;//��ͣ��ť
    public GameObject button_SeeEnemy;//����Ԥ����ť
    public GameObject button_changeLibraryToC;
    public GameObject button_changeLibraryToE;
    public GameObject button_returnToLevelC;
    public GameObject button_returnToLevelE;
    public GameObject canvas_LibraryOfEnemy;
    public GameObject canvas_LibraryOfCharacter;
    public Text startLevelName;
    public List<Transform> slots = new List<Transform>();//��10����ť��λ�õ���
    public List<GameObject> attainedCards = new List<GameObject>();//��ӵ�еĽ�ɫ������
    public List<GameObject> selectedCards = new List<GameObject>();//ѡ�еĽ�ɫ��
    public static List<int> selectedCardsIndex_2 = new List<int>();//�����п���ͼ����˳��
    public List<Button> attainedCardsButtons = new List<Button>();
    public List<Button> selectedCardsButtons = new List<Button>();
    //public int attainedCardsNum;/////////////////����GameManager�д洢
    public int filledNum = 0;//��ѡ���ɫ��
    public static int maxCardNumHere=6;//��󿨲���
    public static bool initialize = true;
    public bool isInLibrary=false;
    // Start is called before the first frame update
    void Start()
    {
        button_Start.GetComponent<Button>().onClick.AddListener(StartGame);
        button_Menu.GetComponent<Button>().onClick.AddListener(ReturnToMenu);
        button_SeeEnemy.GetComponent<Button>().onClick.AddListener(OpenLibraryEnemy_Review);
        button_changeLibraryToC.GetComponent<Button>().onClick.AddListener(OpenLibraryC);
        button_changeLibraryToE.GetComponent<Button>().onClick.AddListener(OpenLibraryE);
        button_returnToLevelC.GetComponent<Button>().onClick.AddListener(ReturnToLevel);
        button_returnToLevelE.GetComponent<Button>().onClick.AddListener(ReturnToLevel);
        initialize = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(filledNum==0)//��ѡ���޷������ʼ
        {
            button_Start.GetComponent<Button>().interactable = false;
        }else
        {
            button_Start.GetComponent<Button>().interactable = true;
        }

        if(initialize)
        {
            Canvas_LibraryOfEnemy.checkMode = 2;
            startLevelName.text = GameManager.LevelNames[GameManager.curLevelID];
            attainedCards.Clear();
            attainedCardsButtons.Clear();
            for (int i = 0; i < GameManager.maxCardsNum; i++)
            {
                slots[i].gameObject.transform.parent.gameObject.SetActive(true);//�ҵ���ť�ĸ����岢���ã���ťҲ����
                slots[i].gameObject.SetActive(false);
            }
            for (int i = GameManager.maxCardsNum; i < 10; i++)
            {
                slots[i].gameObject.transform.parent.gameObject.SetActive(false);//��ʣ�µİ�ť�ĸ��������
            }
            for (int i = 0; i < GameManager.cardsMaxCharacter; i++)
            {
                attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
                attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());//�ҵ�ÿһ����ť��Button������������List
                attainedCards[i].GetComponent<EventTrigger>().enabled = false;
                int temp_1 = i;
                attainedCardsButtons[i].onClick.RemoveAllListeners();
                attainedCardsButtons[i].onClick.AddListener(delegate { SelectingMove(temp_1); });//ÿһ����ť���Ӽ����¼��������ݲ�����temp_1��ԭ������ţ�̫nice�ˣ�������
                attainedCards[i].SetActive(false);
            }
            canvas_LibraryOfCharacter.SetActive(true);
            canvas_LibraryOfCharacter.SetActive(false);
            for (int i = 0; i < Canvas_LibraryOfCharacter.attainedNumPerLevel[GameManager.curLevelID]; i++)
            {
                attainedCards[i].SetActive(true);
            }
            initialize = false;
        }
    }
    public void SelectingMove(int index_1) 
    {
        if(filledNum<maxCardNumHere)
        {
            SoundManager.instance.PlaySound(Globals.SelectCard);
            Vector3 targetPosition = slots[filledNum].transform.position;       //�ҵ������е�λ��
            attainedCardsButtons[index_1].interactable = false;                //ѡ�е�ֲ�ﲻ���ٵ�
            GameObject selectedObject = Instantiate(attainedCards[index_1], slots[filledNum].position, slots[filledNum].rotation, slots[filledNum].parent);
            //��ѡ�еĽ�ɫ�ڿ���������Ϊ����        
            selectedObject.transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
            selectedObject.GetComponent<Card>().enabled = false;                 //��������ȴ�Ȳ���
            selectedObject.GetComponent<Button>().interactable = true;           //���Ե��
            selectedObject.GetComponent<EventTrigger>().enabled = false;         //�����϶�
            selectedCards.Add(selectedObject);                                  //��ӵ�ѡ������List
            selectedCardsButtons.Add(selectedCards[filledNum].GetComponent<Button>());
            int temp_1 = index_1;                                               //ͼ���е�˳��
            int temp_2 = filledNum;                                             //�����е�˳��
            selectedCardsIndex_2.Add(temp_1);                                   //�����п���ͼ����˳�����List
            selectedCardsButtons[filledNum].onClick.AddListener(delegate { RemovingMove(temp_1, temp_2); });
            //Debug.Log("ͼ�����" + temp_1 + " �������" + temp_2 + "��+�Ƴ�����������");
            filledNum++;
            LibraryOfCharacter.ALLCharacters[temp_1].friendshipEXP += 1;///////�����ã�ÿѡ��һ�ο�EXP+1
            LibraryOfCharacter.UpdateFreindship(temp_1);
        }
        
    }
    public void RemovingMove(int index_1,int index_2)
    {
        //Debug.Log("���ü���" +index_1+ index_2);
        SoundManager.instance.PlaySound(Globals.RemoveCard);
        attainedCardsButtons[index_1].interactable= true;
        Destroy(selectedCards[index_2]);
        for(int i=index_2+1;i<=selectedCards.Count-1;i++)
        {
            //Debug.Log("��ǰ�������"+i+" ��ɾ���Ŀ��Ŀ������"+index_2);
            int temp_0 = selectedCardsIndex_2[i];
            int temp_2 = i;
            selectedCards[i].transform.position = slots[i-1].position;
            selectedCardsButtons[i].onClick.RemoveAllListeners()/*Listener(delegate { RemovingMove(temp_0, temp_2); })*/;
            //Debug.Log("-�Ƴ���������" + temp_0 + temp_2);
            selectedCardsButtons[i].onClick.AddListener(delegate { RemovingMove(temp_0, temp_2-1); });
        }
        filledNum--;
        selectedCards.Remove(selectedCards[index_2]);
        selectedCardsButtons.Remove(selectedCardsButtons[index_2]);
        selectedCardsIndex_2.Remove(selectedCardsIndex_2[index_2]);
    }
    public void StartGame()
    {
        //if (filledNum != 0)//����Ҫ�жϡ���undate���жϹ���
        {
            SoundManager.instance.PlaySound(Globals.StartLevel);

            GameManager.initialize = true;
            GameManager.gameStart = true;
            ProgressBar.initialize = true;
            button_Menu.SetActive(false);
            button_TimeSpeed.SetActive(true);
            button_Pause.SetActive(true);
            panel_SelectCard.SetActive(false);
            for(int i=0;i<filledNum;i++)
            {
                selectedCards[i].transform.GetChild(0).gameObject.SetActive(true);
                selectedCards[i].transform.GetChild(1).gameObject.SetActive(true);
                selectedCards[i].GetComponent<Card>().enabled = true;               //��ʼ��ȴ
                selectedCardsButtons[i].onClick.RemoveAllListeners();
                selectedCardsButtons[i].GetComponent<EventTrigger>().enabled = true;//�����϶�
            }
        }
    }
    public void OpenLibraryEnemy_Review()
    {
        isInLibrary = true;
        SoundManager.instance.PlaySound(Globals.Open0);
        Canvas_LibraryOfEnemy.checkMode = 2;
        Canvas_LibraryOfEnemy.initialize= true;
        canvas_LibraryOfEnemy.SetActive(true);
    }
    public void OpenLibraryC()
    {
        Canvas_LibraryOfCharacter.initialize = true;
        canvas_LibraryOfEnemy.SetActive(false);
        canvas_LibraryOfCharacter.SetActive(true);
    }
    public void OpenLibraryE()
    {
        canvas_LibraryOfEnemy.SetActive(true);
        canvas_LibraryOfCharacter.SetActive(false);
    }
    public void ReturnToLevel()
    {
        SoundManager.instance.PlaySound(Globals.Return0);
        isInLibrary = false;
        canvas_LibraryOfEnemy.SetActive(false);
        canvas_LibraryOfCharacter.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Canvas_LibraryOfEnemy.checkMode = 1;
        SceneManager.LoadScene(0);
    }
}
