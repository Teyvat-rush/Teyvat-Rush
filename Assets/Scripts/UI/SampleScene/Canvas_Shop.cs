using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Shop : MonoBehaviour
{
    class Items
    {
        int m_price;
        int m_count;
        Text m_description;
        Text m_name;
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

    public List<GameObject> panels= new List<GameObject>();//ҳ����Ӧ�õ��ڹ�����,�ֶ����
    public List<Sprite> images = new List<Sprite>();////////////�ֶ����
    public List<GameObject> buttons_item= new List<GameObject>();
    public List<int> remainingNum;//�������
    public List<int> price;//�۸��
    public List<bool> purchasedState=new List<bool>();//true:SOLDOUT
    public bool isFirst = true;
    public int itemsCount = 4;///////////////////��Ʒ����������������
    public int index_panel;//ҳ����ţ�һҳ12��������...��
    public int index_selected_item;//ѡ�е����
    // Start is called before the first frame update
    void Start()
    {
        
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        button_Cancel.GetComponent<Button>().onClick.AddListener(CancelMove);
        button_Purchase.GetComponent<Button>().onClick.AddListener(PurchaseMove);
        button_minus.GetComponent<Button>().onClick.AddListener(MinusMove);
        button_plus.GetComponent<Button>().onClick.AddListener(PlusMove);
        


        for (int i=0;i<itemsCount;i++)
        {
            buttons_item.Add(panels[(int)(i / 12f)].transform.GetChild(i % 12).gameObject);//ÿ��ҳ��12��item
            remainingNum.Add(2);//////Ĭ�Ͽ��1��
            price.Add(int.Parse(buttons_item[i].transform.GetChild(2).gameObject.GetComponent<Text>().text));
            int temp = i;
            buttons_item[i].GetComponent<Button>().onClick.AddListener(delegate { OpenDetail(temp); }) ;
        }
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        if(isFirst)//��һ�ν���Ϸ�ĳ�ʼ��
        {
            index_panel = 0;
            index_selected_item = 0;
            for (int i = 0; i <itemsCount; i++)
            {
                purchasedState.Add(false);
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
        if(remainingNum[index_selected_item]==0)
        {
            buttons_item[index_selected_item].GetComponent<Button>().interactable = false;
            buttons_item[index_selected_item].transform.GetChild(3).gameObject.SetActive(true);
            purchasedState[index_selected_item] = true;
        }
        if(text_PurchasedNum_Int.GetComponent<Text>().text=="0")
        {
            Canvas_Achievement.progress[1] += 1;////////////�ɾ����1
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
