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
    public GameObject panel_SelectCard;//选卡框
    public GameObject panel_Cards;//已有角色卡的一级父物体
    public GameObject button_Start;//开始按钮
    public GameObject button_Menu;//主菜单按钮
    public GameObject button_TimeSpeed;//倍速按钮
    public GameObject button_Pause;//暂停按钮
    public List<Transform> slots = new List<Transform>();//将10个按钮的位置导入
    public List<GameObject> attainedCards = new List<GameObject>();//将拥有的角色卡导入
    public List<GameObject> selectedCards = new List<GameObject>();//选中的角色卡
    public List<int> selectedCardsIndex_2 = new List<int>();//卡槽中卡的图鉴的顺序
    public List<Button> unselectedCardsButtons = new List<Button>();
    public List<Button> selectedCardsButtons = new List<Button>();
    public int attainedCardsNum;
    public int filledNum = 0;//已选择角色数
    public int maxCardNumHere;//最大卡槽数
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gameStart = false;
        button_Start.GetComponent<Button>().onClick.AddListener(StartGame);
        attainedCardsNum = 3;////////////////////////////////读取关卡进度，改变拥有角色数
        for(int i=0;i<attainedCardsNum;i++)
        {
            attainedCards.Add(panel_Cards.transform.GetChild(i).gameObject);
        }
        maxCardNumHere = GameManager.instance.maxCardNum;//////////////////////////////////读取关卡进度，获取最大卡槽数
        for (int i = 0; i < maxCardNumHere; i++)
        {
            slots[i].gameObject.transform.parent.gameObject.SetActive(true);//找到按钮的父物体并启用，按钮也启用
            //slots[i].gameObject.SetActive(true);
        }
        for(int i = maxCardNumHere;i<10;i++)
        {
            slots[i].gameObject.transform.parent.gameObject.SetActive(false);//将剩下的按钮的父物体禁用
        }
        for (int i = 0; i < attainedCardsNum; i++)
        {
            unselectedCardsButtons.Add(attainedCards[i].GetComponent<Button>());//找到每一个按钮的Button组件并加入这个List
            attainedCards[i].GetComponent<EventTrigger>().enabled= false;
            int temp_1 = i;
            unselectedCardsButtons[i].onClick.AddListener(delegate {SelectingMove(temp_1);});//每一个按钮增加监听事件，并传递参数，temp_1是原来的序号（太nice了！！！）
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(filledNum==0)//不选人无法点击开始
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
            Vector3 targetPosition = slots[filledNum].transform.position;       //找到卡槽中的位置
            unselectedCardsButtons[index_1].interactable = false;                //选中的植物不能再点
            GameObject selectedObject = Instantiate(attainedCards[index_1], slots[filledNum].position, slots[filledNum].rotation, slots[filledNum].parent);
            //将选中的角色在卡槽中生成为物体        
            selectedObject.transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
            selectedObject.GetComponent<Card>().enabled = false;                 //不进行冷却等操作
            selectedObject.GetComponent<Button>().interactable = true;           //可以点击
            selectedObject.GetComponent<EventTrigger>().enabled = false;         //不能拖动
            selectedCards.Add(selectedObject);                                  //添加到选中物体List
            selectedCardsButtons.Add(selectedCards[filledNum].GetComponent<Button>());
            int temp_1 = index_1;                                               //图鉴中的顺序
            int temp_2 = filledNum;                                             //卡槽中的顺序
            selectedCardsIndex_2.Add(temp_1);                                   //卡槽中卡的图鉴的顺序存入List
            selectedCardsButtons[filledNum].onClick.AddListener(delegate { RemovingMove(temp_1, temp_2); });
            //Debug.Log("图鉴序号" + temp_1 + " 卡槽序号" + temp_2 + "（+移除动作监听）");
            filledNum++;
        }
        
    }
    public void RemovingMove(int index_1,int index_2)
    {
        //Debug.Log("调用监听" +index_1+ index_2);
        //Vector3 targetPosition = unselectedCards[index_1].transform.position;
        unselectedCardsButtons[index_1].interactable= true;
        Destroy(selectedCards[index_2]);
        for(int i=index_2+1;i<=selectedCards.Count-1;i++)
        {
            //Debug.Log("当前卡槽序号"+i+" 被删除的卡的卡槽序号"+index_2);
            //if (i == selectedCards.Count) return;
            int temp_0 = selectedCardsIndex_2[i];
            int temp_2 = i;
            selectedCards[i].transform.position = slots[i-1].position;
            selectedCardsButtons[i].onClick.RemoveAllListeners()/*Listener(delegate { RemovingMove(temp_0, temp_2); })*/;
            //Debug.Log("-移除动作监听" + temp_0 + temp_2);
            selectedCardsButtons[i].onClick.AddListener(delegate { RemovingMove(temp_0, temp_2-1); });
        }
        filledNum--;
        selectedCards.Remove(selectedCards[index_2]);
        selectedCardsButtons.Remove(selectedCardsButtons[index_2]);
        selectedCardsIndex_2.Remove(selectedCardsIndex_2[index_2]);
    }
    public void StartGame()
    {
        //if (filledNum != 0)//不需要判断。。undate里判断过了
        {
            GameManager.instance.gameStart = true;
            button_Menu.SetActive(false);
            button_TimeSpeed.SetActive(true);
            button_Pause.SetActive(true);
            panel_SelectCard.SetActive(false);
            for(int i=0;i<maxCardNumHere;i++)
            {
                selectedCardsButtons[i].GetComponent<EventTrigger>().enabled = true;//可以拖动
            }
        }
    }
}
