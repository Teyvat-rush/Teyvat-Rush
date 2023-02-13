using JetBrains.Annotations;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Canvas_Shop : MonoBehaviour
{
    //public class Items
    //{
    //    public int m_price;
    //    public int m_count;
    //    public string m_description;
    //    public string m_name;
    //    public Items(int price, int count, string description, string name)
    //    {
    //        m_price = price;
    //        m_count = count;
    //        m_description = description;
    //        m_name = name;
    //    }
    //}//�����ڳ�ʼ����������Ϸ���ȸı��κ�ֵ���ѷ�����
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

    public List<GameObject> panels= new List<GameObject>();////////ҳ����Ӧ�õ��ڹ�����,�ֶ����
    public List<Sprite> images = new List<Sprite>();////////////�ֶ����
    public List<GameObject> buttons_item= new List<GameObject>();
    //public static List<int> remainingNum=new List<int>();//�������
    //public List<int> price;//�۸��
    //public static List<bool> purchasedState=new List<bool>();//true:SOLDOUT
    //public static List<int> effectiveNum = new List<int>();
    //public static bool isFirst = true;
    //public int itemsCount;
    public int unlockedPerLevel;
    public int index_panel;//ҳ����ţ�һҳ12��������...��
    public int index_selected_item;//ѡ�е����
    public static bool initialize = true; 

    // Start is called before the first frame update
    void Awake()
    {
        initialize = true;
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        button_Cancel.GetComponent<Button>().onClick.AddListener(CancelMove);
        button_Purchase.GetComponent<Button>().onClick.AddListener(PurchaseMove);
        button_minus.GetComponent<Button>().onClick.AddListener(MinusMove);
        button_plus.GetComponent<Button>().onClick.AddListener(PlusMove);
        button_Menu.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
        //items.Add(new Items(1145, 1, "�����ɵµ�ͼ���ߵ���󣬵��˽Ӵ�ʱ���յǳ����һ�������е��ˡ�", "ľ׮"));
        //items.Add(new Items(114, 4, "ʹ�����Я������������+1��", "�����ӡ�1"));
        //if (isFirst)//��һ�ν���Ϸ�ĳ�ʼ��
        //{
            
        //    for (int i = 0; i <itemsCount; i++)
        //    {
        //        purchasedState.Add(false);
        //        //effectiveNum.Add(0);
        //    }
        //    gameObject.SetActive(false);
        //    isFirst = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(initialize)
        {
            index_panel = 0;
            index_selected_item = 0;
            unlockedPerLevel = GameManager.shop.unlockedPerLevel[GameManager.gamemanagerr.curLevelID];
            buttons_item.Clear();
            for (int i = 0; i < GameManager.shop.itemsTotalCount; i++)
            {
                buttons_item.Add(panels[(int)(i / 12f)].transform.GetChild(i % 12).gameObject);//ÿ��ҳ��12��item
                int temp = i;
                buttons_item[i].GetComponent<Button>().onClick.RemoveAllListeners();
                buttons_item[i].GetComponent<Button>().onClick.AddListener(delegate { OpenDetail(temp); });
                buttons_item[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = GameManager.shop.items[i].price.ToString();
            }
            for (int i = 0; i < unlockedPerLevel; i++)
            {
                buttons_item[i].SetActive(true);
            }
            for (int i = unlockedPerLevel; i < GameManager.shop.itemsTotalCount; i++)
            {
                buttons_item[i].SetActive(false);
            }
            for (int i = 0; i < unlockedPerLevel; i++)
            {
                if (GameManager.shop.items[i].purchasedState)
                {
                    buttons_item[i].GetComponent<Button>().interactable = false;
                    buttons_item[i].transform.GetChild(3).gameObject.SetActive(true);
                }
            }
            initialize = false;
        }

    }
    public void OpenMainMenu()
    {
        SoundManager.instance.PlaySound(Globals.Return1);
        canvas_MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OpenDetail(int index)
    {
        SoundManager.instance.PlaySound(Globals.Open1);
        index_selected_item = index;
        panel_ConfirmPurchase.SetActive(true);
        text_Item.GetComponent<Text>().text = GameManager.shop.items[index].name;
        text_Description.GetComponent<Text>().text = GameManager.shop.items[index].description;
        image_Item.GetComponent<Image>().sprite = images[index];
        text_TotalPrice.GetComponent<Text>().text = GameManager.shop.items[index].price.ToString();//Ĭ��һ��
        text_PurchasedNum_Int.GetComponent<Text>().text = 1.ToString();//Ĭ��һ��
        if (text_PurchasedNum_Int.GetComponent<Text>().text == GameManager.shop.items[index_selected_item].remainingNum.ToString())
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = false;
        }else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }
        text_RemainingNum_Int.GetComponent<Text>().text = GameManager.shop.items[index].remainingNum.ToString();

        if (int.Parse(text_TotalPrice.GetComponent<Text>().text) > GameManager.gamemanagerr.mora)
        {
            button_Purchase.GetComponent<Button>().interactable = false;
            button_plus.GetComponent<Button>().interactable = false;
        }
        else
        {
            button_Purchase.GetComponent<Button>().interactable = true;
        }
    }
    public void CancelMove()
    {
        SoundManager.instance.PlaySound(Globals.Return0);
        panel_ConfirmPurchase.SetActive(false);
    }
    public void PurchaseMove()
    {
        SoundManager.instance.PlaySound(Globals.Attain0);
        panel_ConfirmPurchase.SetActive(false);

        
        GameManager.gamemanagerr.mora = (GameManager.gamemanagerr.mora - int.Parse(text_TotalPrice.GetComponent<Text>().text));
        string json = JsonUtility.ToJson(GameManager.gamemanagerr, true);
        File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json);
        //string json_Mora = JsonUtility.ToJson(DataManager.instance.coin);
        //string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
        //using (StreamWriter streamWriter = new StreamWriter(filepath_Mora))
        //{
        //    streamWriter.WriteLine(json_Mora);
        //    streamWriter.Close();
        //    streamWriter.Dispose();
        //}

        GameManager.shop.items[index_selected_item].remainingNum -= int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text);
        if (GameManager.shop.items[index_selected_item].remainingNum ==0)
        {
            buttons_item[index_selected_item].GetComponent<Button>().interactable = false;
            buttons_item[index_selected_item].transform.GetChild(3).gameObject.SetActive(true);
            GameManager.shop.items[index_selected_item].purchasedState = true;
        }
        if(text_PurchasedNum_Int.GetComponent<Text>().text=="0")
        {
            GameManager.achievement.l[1].progress += 1;////////////�ɾ����1
        }
        if (index_selected_item==1)
        {
            GameManager.gamemanagerr.maxCardsNum += int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text);
            Debug.Log("����0 ��󿨲���(GameManager.gamemanagerr.maxCardsNum)" + GameManager.gamemanagerr.maxCardsNum);
            CardSlot.initialize = true;
        }
        string json1 = JsonUtility.ToJson(GameManager.achievement, true);
        File.WriteAllText(Application.streamingAssetsPath + "/Achievement.json", json1);
        string json2 = JsonUtility.ToJson(GameManager.shop, true);
        File.WriteAllText(Application.streamingAssetsPath + "/Shop.json", json2);
        string json0 = JsonUtility.ToJson(GameManager.gamemanagerr, true);
        File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json0);
    }
    public void MinusMove()
    {
        SoundManager.instance.PlaySound(Globals.Open1);
        text_PurchasedNum_Int.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text)-1).ToString();
        text_TotalPrice.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) * GameManager.shop.items[index_selected_item].price).ToString();
        if (text_PurchasedNum_Int.GetComponent<Text>().text == "0")
        {
            button_minus.GetComponent<Button>().interactable = false;
            button_plus.GetComponent<Button>().interactable = true;
            button_Purchase.GetComponent<Button>().interactable = false;
        }else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }

        if (int.Parse(text_TotalPrice.GetComponent<Text>().text) > GameManager.gamemanagerr.mora)
        {
            button_Purchase.GetComponent<Button>().interactable = false;
        }else
        {
            button_Purchase.GetComponent<Button>().interactable = true;
        }

    }

    public void PlusMove()
    {
        SoundManager.instance.PlaySound(Globals.Open1);
        button_Purchase.GetComponent<Button>().interactable = true;
        text_PurchasedNum_Int.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) + 1).ToString();
        text_TotalPrice.GetComponent<Text>().text = (int.Parse(text_PurchasedNum_Int.GetComponent<Text>().text) * GameManager.shop.items[index_selected_item].price).ToString();
        if (text_PurchasedNum_Int.GetComponent<Text>().text == GameManager.shop.items[index_selected_item].remainingNum.ToString())
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = false;
        }else
        {
            button_minus.GetComponent<Button>().interactable = true;
            button_plus.GetComponent<Button>().interactable = true;
        }

        if (int.Parse(text_TotalPrice.GetComponent<Text>().text) > GameManager.gamemanagerr.mora)
        {
            button_plus.GetComponent<Button>().interactable = false;
            button_Purchase.GetComponent<Button>().interactable = false;
        }else
        {
            button_Purchase.GetComponent<Button>().interactable = true;
        }
        

    }
}
