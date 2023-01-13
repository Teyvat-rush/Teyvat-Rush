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
    }//�����ڳ�ʼ����������Ϸ���ȸı��κ�ֵ

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
    public List<GameObject> panels= new List<GameObject>();//ҳ����Ӧ�õ��ڹ�����,�ֶ����
    public List<Sprite> images = new List<Sprite>();////////////�ֶ����
    public List<GameObject> buttons_item= new List<GameObject>();
    public List<int> remainingNum;//�������
    public List<int> price;//�۸��
    public static List<bool> purchasedState=new List<bool>();//true:SOLDOUT
    //public static List<int> effectiveNum = new List<int>();
    public bool isFirst = true;
    public int itemsCount = 2;///////////////////��Ʒ����������������
    public int index_panel;//ҳ����ţ�һҳ12��������...��
    public int index_selected_item;//ѡ�е����




    // Start is called before the first frame update
    void Awake()
    {
        
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        button_Cancel.GetComponent<Button>().onClick.AddListener(CancelMove);
        button_Purchase.GetComponent<Button>().onClick.AddListener(PurchaseMove);
        button_minus.GetComponent<Button>().onClick.AddListener(MinusMove);
        button_plus.GetComponent<Button>().onClick.AddListener(PlusMove);

        items.Add(new Items(114514, 1, "�����ɵµ�ͼ���ߵ���󣬵��˽Ӵ�ʱ���յǳ����һ�������е��ˡ�", "ľ׮"));
        items.Add(new Items(11450, 8, "ʹ�����Я������������+1��", "�����ӡ�1"));

        for (int i=0;i<itemsCount;i++)
        {
            buttons_item.Add(panels[(int)(i / 12f)].transform.GetChild(i % 12).gameObject);//ÿ��ҳ��12��item
            remainingNum.Add(items[i].m_count);
            price.Add(items[i].m_price);
            int temp = i;
            buttons_item[i].GetComponent<Button>().onClick.AddListener(delegate { OpenDetail(temp); }) ;
            buttons_item[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = price[i].ToString();
        }
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        



        if (isFirst)//��һ�ν���Ϸ�ĳ�ʼ��
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
        text_TotalPrice.GetComponent<Text>().text = price[index].ToString();//Ĭ��һ��
        text_PurchasedNum_Int.GetComponent<Text>().text = 1.ToString();//Ĭ��һ��
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
            purchasedState[index_selected_item] = true;///////////GameManager��ȡ����״̬
        }
        if(text_PurchasedNum_Int.GetComponent<Text>().text=="0")
        {
            Canvas_Achievement.progress[1] += 1;////////////�ɾ����1
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
