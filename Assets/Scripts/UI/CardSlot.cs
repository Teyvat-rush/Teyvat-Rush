using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
    public List<Transform> slots = new List<Transform>();//��10����ť��λ�õ���
    public List<GameObject> attainedCards = new List<GameObject>();//��ӵ�еĽ�ɫ������
    public List<GameObject> selectedCards = new List<GameObject>();//ѡ�еĽ�ɫ��
    public List<int> selectedCardsIndex_2 = new List<int>();//�����п���ͼ����˳��
    public List<Button> attainedCardsButtons = new List<Button>();
    public List<Button> selectedCardsButtons = new List<Button>();
    public int attainedCardsNum;
    public int filledNum = 0;//��ѡ���ɫ��
    public int maxCardNumHere;//��󿨲���
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gameStart = false;
        button_Start.GetComponent<Button>().onClick.AddListener(StartGame);
        button_SeeEnemy.GetComponent<Button>().onClick.AddListener(OpenLibraryEnemy_Review);
        button_changeLibraryToC.GetComponent<Button>().onClick.AddListener(OpenLibraryC);
        button_changeLibraryToE.GetComponent<Button>().onClick.AddListener(OpenLibraryE);
        button_returnToLevelC.GetComponent<Button>().onClick.AddListener(ReturnToLevel);
        button_returnToLevelE.GetComponent<Button>().onClick.AddListener(ReturnToLevel);

        attainedCardsNum = 3;////////////////////////////////��ȡ�ؿ����ȣ��ı�ӵ�н�ɫ��
        for(int i=0;i<attainedCardsNum;i++)
        {
            attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
        }
        maxCardNumHere = GameManager.instance.maxCardNum;//////////////////////////////////��ȡ�ؿ����ȣ���ȡ��󿨲���
        for (int i = 0; i < maxCardNumHere; i++)
        {
            slots[i].gameObject.transform.parent.gameObject.SetActive(true);//�ҵ���ť�ĸ����岢���ã���ťҲ����
            //slots[i].gameObject.SetActive(true);
        }
        for(int i = maxCardNumHere;i<10;i++)
        {
            slots[i].gameObject.transform.parent.gameObject.SetActive(false);//��ʣ�µİ�ť�ĸ��������
        }
        for (int i = 0; i < attainedCardsNum; i++)
        {
            attainedCardsButtons.Add(attainedCards[i].GetComponent<Button>());//�ҵ�ÿһ����ť��Button������������List
            attainedCards[i].GetComponent<EventTrigger>().enabled= false;
            int temp_1 = i;
            attainedCardsButtons[i].onClick.AddListener(delegate {SelectingMove(temp_1);});//ÿһ����ť���Ӽ����¼��������ݲ�����temp_1��ԭ������ţ�̫nice�ˣ�������
        }
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
    }
    public void SelectingMove(int index_1) 
    {
        if(filledNum<maxCardNumHere)
        {
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
        }
        
    }
    public void RemovingMove(int index_1,int index_2)
    {
        //Debug.Log("���ü���" +index_1+ index_2);
        //Vector3 targetPosition = unselectedCards[index_1].transform.position;
        attainedCardsButtons[index_1].interactable= true;
        Destroy(selectedCards[index_2]);
        for(int i=index_2+1;i<=selectedCards.Count-1;i++)
        {
            //Debug.Log("��ǰ�������"+i+" ��ɾ���Ŀ��Ŀ������"+index_2);
            //if (i == selectedCards.Count) return;
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
            GameManager.instance.gameStart = true;
            button_Menu.SetActive(false);
            button_TimeSpeed.SetActive(true);
            button_Pause.SetActive(true);
            panel_SelectCard.SetActive(false);
            for(int i=0;i<filledNum;i++)
            {
                selectedCards[i].transform.GetChild(0).gameObject.SetActive(false);
                selectedCards[i].transform.GetChild(1).gameObject.SetActive(true);
                selectedCards[i].GetComponent<Card>().enabled = true;
                selectedCardsButtons[i].onClick.RemoveAllListeners();
                //selectedCardsButtons[i].interactable=false;
                selectedCardsButtons[i].GetComponent<EventTrigger>().enabled = true;//�����϶�
            }
        }
    }
    public void OpenLibraryEnemy_Review()
    {
        GameManager.instance.isBattling= true;/////////////////��Ӧ������������isBattling��ֵ��GameManager��ǰ����.
        canvas_LibraryOfEnemy.SetActive(true);
    }
    public void OpenLibraryC()
    {
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
        canvas_LibraryOfEnemy.SetActive(false);
        canvas_LibraryOfCharacter.SetActive(false);
    }
}
