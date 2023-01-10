using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class Canvas_Achievement : MonoBehaviour
{
    public GameObject panel_Achievements;
    public GameObject panel_RewardIndex;
    public Text text_AchievedNum;
    public Text text_Indexs;
    public List<Button> button_Attain;//全部未未达成成就的领取按钮
    public List<Transform> notAchieved;//全部未达成成就的位置
    public List<int> index_2;//未完成列表中的成就序号，初始状态第0个位置的成就序号为0，以此类推
    public List<int> progress;
    public List<int> target;
    public List<bool> AchieveState;//各成就达成状态
    public int ALLAchievedNum;
    public int achievedNum;
    public bool isFirst=true;
    public bool isRemainingReward;//true:有奖励没领取
    public static bool initiate = true;
    // Start is called before the first frame update
    void Start()
    {
        ALLAchievedNum = 2;//////////手动更新总成就个数

        if (isFirst)////////////是否首次进入游戏
        {
            achievedNum = 0;
            isRemainingReward= false;
            for (int i = 0; i < ALLAchievedNum; i++)
            {
                notAchieved.Add(panel_Achievements.transform.GetChild(i));
                button_Attain.Add(notAchieved[i].GetChild(4).GetComponent<Button>());///////////注意GetChild括号，可能有变动
                index_2.Add(i);//////////////后续暂时没用到，因为没有把已领取的成就分离出去
                progress.Add(0);
                target.Add(int.Parse(button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(2).GetComponent<Text>().text));
                AchieveState.Add(false);
                int temp_1 = i;//图鉴中的位置
                int temp_2 = i;//成就序号
                Debug.Log(temp_1+"  "+temp_2);
                button_Attain[i].onClick.AddListener(delegate{AttainedMove(temp_1,temp_2);});
            }
            isFirst = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initiate) 
        {
            
            text_Indexs.text = "";
            isRemainingReward = false;
            for (int i = 0; i < ALLAchievedNum; i++)
            {
                button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(0).GetComponent<Text>().text = progress[i].ToString();
                if (progress[i] >= target[i]&& AchieveState[i]==false)
                {
                    isRemainingReward = true;
                    button_Attain[i].gameObject.SetActive(true);
                    button_Attain[i].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                    text_Indexs.text += " ";
                    text_Indexs.text += i.ToString();
                }
            }
            if(isRemainingReward)
            {
                panel_RewardIndex.SetActive(true);
            }else
            {
                panel_RewardIndex.SetActive(false);
            }
            text_AchievedNum.text = achievedNum.ToString();
            initiate= false;
        }
        
    }
    
    public void AttainedMove(int n1,int n2)
    {
        //Debug.Log("1");
        achievedNum++;
        button_Attain[n2].interactable = false;
        //Debug.Log("1");
        button_Attain[n2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "已领取";
        button_Attain[n2].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
        //Debug.Log("1");
        AchieveState[n2] = true;
        initiate= true;//每领取一次刷新一遍图鉴
    }
}
