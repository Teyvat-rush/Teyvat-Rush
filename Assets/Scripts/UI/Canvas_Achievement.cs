using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Canvas_Achievement : MonoBehaviour
{
    public GameObject panel_Achievements;
    public GameObject panel_RewardIndex;
    public Text text_AchievedNum;
    public Text text_Indexs;
    public static List<Button> button_Attain=new List<Button>();//全部未未达成成就的领取按钮
    public static List<Transform> notAchieved = new List<Transform>();//全部未达成成就的位置
    public static List<int> index_2 = new List<int>();//未完成列表中的成就序号，初始状态第0个位置的成就序号为0，以此类推
    //public static List<int> progress = new List<int>();
    //public static List<int> target=new List<int>();
    //public static List<bool> AchieveState = new List<bool>();//各成就达成状态
    //public static int ALLAchievedNum;
    //public static int achievedNum;
    public static bool isFirst=true;//进游戏(无论是否第一次开游戏)后是否第一次打开此面板
    public bool isRemainingReward;//true:有奖励没领取
    public static bool initialize = true;
    // Start is called before the first frame update
    public void Awake()
    {
        initialize = true;
        notAchieved.Clear();
        button_Attain.Clear();
        for (int i = 0; i < GameManager.achievement.ALLCount; i++)
        {
            notAchieved.Add(panel_Achievements.transform.GetChild(i));
            button_Attain.Add(notAchieved[i].GetChild(4).GetComponent<Button>());
            int temp_1 = i;//图鉴中的位置
            int temp_2 = i;//成就序号
            button_Attain[i].onClick.RemoveAllListeners();
            button_Attain[i].onClick.AddListener(delegate { AttainedMove(temp_1, temp_2); });
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if(initialize) 
        {
            text_Indexs.text = "";
            isRemainingReward = false;
            for (int i = 0; i < GameManager.achievement.ALLCount; i++)
            {
                
                if (button_Attain[i] != null)
                {
                    button_Attain[i].gameObject.transform.parent.GetChild(0).gameObject.GetComponent<Text>().text = GameManager.achievement.l[i].name;
                    button_Attain[i].gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.achievement.l[i].description;
                    button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.achievement.l[i].progress.ToString();
                    button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(2).gameObject.GetComponent<Text>().text = GameManager.achievement.l[i].target.ToString();
                    button_Attain[i].gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.achievement.l[i].rewardNum.ToString();
                    Debug.Log("成就" + i + "进度" + GameManager.achievement.l[i].progress+"/" + GameManager.achievement.l[i].target);
                    if ((GameManager.achievement.l[i].progress >= GameManager.achievement.l[i].target) && (GameManager.achievement.l[i].achievedState == false))
                    {
                        isRemainingReward = true;
                        Debug.Log("显示第" + i + "个领取按钮");
                        button_Attain[i].gameObject.SetActive(true);
                        button_Attain[i].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                        text_Indexs.text += " ";
                        text_Indexs.text += i.ToString();
                    }
                }
                if (GameManager.achievement.l[i].achievedState)
                {
                    button_Attain[i].gameObject.SetActive(true);
                    button_Attain[i].interactable = false;
                    button_Attain[i].gameObject.transform.GetChild(0).GetComponent<Text>().text = "已领取";
                    button_Attain[i].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                }
                
            }
            if(isRemainingReward)
            {
                panel_RewardIndex.SetActive(true);
            }else
            {
                panel_RewardIndex.SetActive(false);
            }
            text_AchievedNum.text = GameManager.achievement.achievedNum.ToString();
            initialize= false;
        }
        
    }
    
    public void AttainedMove(int n1,int n2)
    {
        SoundManager.instance.PlaySound(Globals.Attain0);
        
        button_Attain[n2].interactable = false;
        button_Attain[n2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "已领取";
        button_Attain[n2].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);

        GameManager.achievement.achievedNum++;
        GameManager.achievement.l[n2].achievedState = true;
        string json = JsonUtility.ToJson(GameManager.achievement, true);
        File.WriteAllText(Application.streamingAssetsPath + "/Achievement.json", json);
        
        GameManager.gamemanagerr.mora += int.Parse(button_Attain[n2].gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text);
        string json1 = JsonUtility.ToJson(GameManager.gamemanagerr, true);
        File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json1);

        initialize = true;//每领取一次刷新一遍图鉴
        //string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
        //using (StreamWriter streamWriter = new StreamWriter(filepath_Mora))
        //{
        //    streamWriter.WriteLine(json_Mora);
        //    streamWriter.Close();
        //    streamWriter.Dispose();
        //}
    }
}
