using JetBrains.Annotations;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Shop : MonoBehaviour
{
    public class Items
    {
        public int m_price;
        public int m_count;
        public string m_description;
        public string m_name;

        public Items(int price, int count, string description, string name)
        {
            m_price = price;
            m_count = count;
            m_description = description;
            m_name = name;
        }
    }//仅用于初始化，不被游戏进度改变任何值

    public GameObject canvas_MainMenu;
    public GameObject panel_ConfirmPurchase;
    public GameObject button_Menu;
    
    public GameObject button_Cancel;
    public GameObject button_Purchase;
    public GameObject text_Item;
    public GameObject text_TotalPrice;
    public GameObject image_Item;
    public GameObject text_Description;
    public GameObject button_minus;
    public GameObject text_PurchasedNum_Int;
    public GameObject text_RemainingNum_Int;
    public GameObject button_plus;

    public Text moras;
    public List<Items> items = new List<Items>();
    public List<GameObject> panels= new List<GameObject>();//页面数应该等于国家数,手动添加
    public List<Sprite> images = new List<Sprite>();////////////手动添加
    public List<GameObject> buttons_item= new List<GameObject>();
    public List<int> remainingNum;//库存数量
    public List<int> price;//价格表
    public static List<bool> purchasedState=new List<bool>();//true:SOLDOUT
    //public static List<int> effectiveNum = new List<int>();
    public bool isFirst = true;
    public int itemsCount = 2;///////////////////物品总种类数，待更新
    public int index_panel;//页面序号，一页12个够多了...吧
    public int index_selected_item;//选中的序号




    // Start is called before the first frame update
    void Awake()
    {
        
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        button_Cancel.GetComponent<Button>().onClick.AddListener(CancelMove);
        button_Purchase.GetComponent<Button>().onClick.AddListener(PurchaseMove);
        button_minus.GetComponent<Button>().onClick.AddListener(MinusMove);
        button_plus.GetComponent<Button>().onClick.AddListener(PlusMove);

        items.Add(new Items(114514, 1, "置于蒙德地图防线的最后，敌人接触时艾琳登场清除一行内所有敌人。", "木桩"));
        items.Add(new Items(11450, 8, "使队伍可携带的人数上限+1。", "扩充编队·1"));

        for (int i=0;i<itemsCount;i++)
        {
            buttons_item.Add(panels[(int)(i / 12f)].transform.GetChild(i % 12).gameObject);//每个页面12个item
            remainingNum.Add(items[i].m_count);
            price.Add(items[i].m_price);
            int temp = i;
            buttons_item[i].GetComponent<Button>().onClick.AddListener(delegate { OpenDetail(temp); }) ;
            buttons_item[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = price[i].ToString();
        }
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        



        if (isFirst)//第一次进游戏的初始化
        {
            
            index_panel = 0;
            index_selected_item = 0;
            for (int i = 0; i <itemsCount; i++)
            {
                purchasedState.Add(false);
                //effectiveNum.Add(0);
            }
            isFirst = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(text_TotalPrice.GetComponent<Text>().text) > int.Parse(moras.text))
        {
            button_Purchase.GetComponent<Button>().interactable = false;
        }
        else
        {
            button_Purchase.GetComponent<Button>().interactable = true;
        }
    }
    public void OpenMainMenu()
    {
        canvas_MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OpenDetail(int index)
    {
        index_selected_item = index;
        panel_ConfirmPurchase.SetActive(true);
        text_Item.GetComponent<Text>().text = items[index].m_name;
        text_Description.GetComponent<Text>().text = items[index].m_description;
        image_Item.GetComponent<Image>().sprite = images[index];
        text_TotalPrice.GetComponent<Text>().text = price[index].ToString();//默认一倍
        text_PurchasedNum_Int.GetComponent<Text>().text = 1.ToString();//默认一倍
        if (text_PurchasedNum_Int.GetComponent<Text>().text == remainingNum[index_selected_item].ToString())
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = false;
        }else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }
        text_RemainingNum_Int.GetComponent<Text>().text = remainingNum[index].ToString();
    }
    public void CancelMove()
    {
        panel_ConfirmPurchase.SetActive(false);
        
    }
    public void PurchaseMove()
    {
        panel_ConfirmPurchase.SetActive(false);
        moras.text = (int.Parse(moras.text)-int.Parse(text_TotalPrice.GetComponent<Text>().text)).ToString();
        remainingNum[index_selected_item] -= int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text);
        if (remainingNum[index_selected_item]==0)
        {
            buttons_item[index_selected_item].GetComponent<Button>().interactable = false;
            buttons_item[index_selected_item].transform.GetChild(3).gameObject.SetActive(true);
            purchasedState[index_selected_item] = true;///////////GameManager读取购买状态
        }
        if(text_PurchasedNum_Int.GetComponent<Text>().text=="0")
        {
            Canvas_Achievement.progress[1] += 1;////////////成就序号1
        }
        if (index_selected_item==1)
        {
            GameManager.maxCardsNum += int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text);
            CardSlot.initialize = true;
        }

    }
    public void MinusMove()
    {
        text_PurchasedNum_Int.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text)-1).ToString();
        text_TotalPrice.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) * price[index_selected_item]).ToString();
        if (text_PurchasedNum_Int.GetComponent<Text>().text == "0")
        {
            button_minus.GetComponent<Button>().interactable = false;
            button_plus.GetComponent<Button>().interactable = true;
            button_Purchase.GetComponent<Button>().interactable = false;
        }
        else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }


    }

    public void PlusMove()
    {
        button_Purchase.GetComponent<Button>().interactable = true;
        text_PurchasedNum_Int.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) + 1).ToString();
        text_TotalPrice.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) * price[index_selected_item]).ToString();
        if (text_PurchasedNum_Int.GetComponent<Text>().text == remainingNum[index_selected_item].ToString())
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = false;
        }else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }

        if (int.Parse(text_TotalPrice.GetComponent<Text>().text) > int.Parse(moras.text))
        {
            button_Purchase.GetComponent<Button>().interactable = false;
        }
        else
        {
            button_Purchase.GetComponent<Button>().interactable = true;
        }

    }
}
