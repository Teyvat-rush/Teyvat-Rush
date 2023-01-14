using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;  //对话框的内容text
    //public GameObject SkipButton; //跳过按钮
    //public GameObject AutoButton; //自动播放按钮
    public GameObject Panel_Dialog; //对话框的panel
    public GameObject Image_Next;
    public GameObject panel_CardSlot;
    public GameObject panel_Sun;
    public GameObject button_Menu;
    public GameObject Panel_ProgressBar;
    public GameObject panel_SelectCard;
    //public Text AutoText; //自动播放按钮的“自动播放”文本的text（用于实现自动手动切换的功能）
    //public GameObject Warning; //提醒玩家按左键继续，可要可不要
    [Header("文本文件")]
    public TextAsset textfile; //剧情文本的txt文件
    public int index; //进行到了第几句话，用于实现基础功能
    public float textSpeed = 0.05f; //每个字多久才能出现

    //[Header("头像")]
    //public GameObject A; //角色的头像以及名字
    //public GameObject B; //角色的头像以及名字
    //因为我直接把名字和头像绑定为父子物体了，所以只声明了一个GameObect
    public bool textStarted;  //判断第一句对话是否开始
    public bool textFinished; //判断这句话是否结束，是“这句话”！
    //float i = 0f; //判断是否为自动还是手动播放

    public List<string> textList = new List<string>(); //将txt文件的对话内容导入列表内
    // Start is called before the first frame update
    void Awake()
    {
        textStarted = false;
        GetTextFromFile(textfile);
        index= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(textFinished)
        {
            Image_Next.SetActive(true);
        }
        else
        {
            Image_Next.SetActive(false);
        }
        textSpeed = 0.05f;
        if (Input.GetKeyDown(KeyCode.Mouse0) && index == textList.Count)
        {
            
            
            EndDialogue();//如果按下鼠标左键并且播放到了最后一句的话就启动结束对话的函数
            
        }

        if(index==0 &&!textStarted)
        {
            textStarted=true;
            StartCoroutine(SetTextUI());//如果按下鼠标左键的同时一句话已经放完了，就继续启动下一句的播放
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && textFinished && gameObject.activeSelf)
        {
            StartCoroutine(SetTextUI());//如果按下鼠标左键的同时一句话已经放完了，就继续启动下一句的播放
            Image_Next.SetActive(false);
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear(); //如果不是第一次调用对话框，就需要把之前一次所有对话的列表给清空
        index = 0; //并且把显示第几句话的index清零
        var lineData = file.text.Split('\n'); //把文本文件以回车分割一句句台词和角色名称
        foreach (var line in lineData)
        {
            textList.Add(line); //把一句句台词录入line列表里
        }
    }

    IEnumerator SetTextUI() //协程函数的标准形式
    {
        textFinished = false; //正在播放，所以bool值为false
        textLabel.text = ""; //可能上一个句子使用结束后还在text上，所以要清空
        for (int i = 0; i < textList[index].Length; i++)
        //按照一句话的一个字慢慢来，如果没有到一句台词最后一个字的话就一直向后
        {
            textLabel.text += textList[index][i]; //往之前已经打出的台词中加进新的文字
            yield return new WaitForSeconds(textSpeed);//等待textSpeed后继续循环
        }
        textFinished = true; //如果跳出循环说明文字已经放完了，所以bool值是true
        index++; //这句话已经放完了，index++跳进下一句话
    }
    public void EndDialogue()
    {//把114514个对话框组件全部隐藏，代表对话已经结束了
        gameObject.SetActive(false);
        panel_CardSlot.SetActive(true);
        panel_Sun.SetActive(true);
        button_Menu.SetActive(true);
        Panel_ProgressBar.SetActive(true);
        panel_SelectCard.SetActive(true);
        StopCoroutine(SetTextUI());
        //QingShan.SetActive(false);
        //Log.SetActive(false);
        //SkipButton.SetActive(false);
        //AutoButton.SetActive(false);
        index = 0; //把目录调整成最开始，这样下一次开始就是从第一句播放
        return;
    }
}
