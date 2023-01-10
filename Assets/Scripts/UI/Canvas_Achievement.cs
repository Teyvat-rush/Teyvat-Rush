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
    public List<Button> button_Attain;//ȫ��δδ��ɳɾ͵���ȡ��ť
    public List<Transform> notAchieved;//ȫ��δ��ɳɾ͵�λ��
    public List<int> index_2;//δ����б��еĳɾ���ţ���ʼ״̬��0��λ�õĳɾ����Ϊ0���Դ�����
    public List<int> progress;
    public List<int> target;
    public List<bool> AchieveState;//���ɾʹ��״̬
    public int ALLAchievedNum;
    public int achievedNum;
    public bool isFirst=true;
    public bool isRemainingReward;//true:�н���û��ȡ
    public static bool initiate = true;
    // Start is called before the first frame update
    void Start()
    {
        ALLAchievedNum = 2;//////////�ֶ������ܳɾ͸���

        if (isFirst)////////////�Ƿ��״ν�����Ϸ
        {
            achievedNum = 0;
            isRemainingReward= false;
            for (int i = 0; i < ALLAchievedNum; i++)
            {
                notAchieved.Add(panel_Achievements.transform.GetChild(i));
                button_Attain.Add(notAchieved[i].GetChild(4).GetComponent<Button>());///////////ע��GetChild���ţ������б䶯
                index_2.Add(i);//////////////������ʱû�õ�����Ϊû�а�����ȡ�ĳɾͷ����ȥ
                progress.Add(0);
                target.Add(int.Parse(button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(2).GetComponent<Text>().text));
                AchieveState.Add(false);
                int temp_1 = i;//ͼ���е�λ��
                int temp_2 = i;//�ɾ����
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
        button_Attain[n2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "����ȡ";
        button_Attain[n2].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
        //Debug.Log("1");
        AchieveState[n2] = true;
        initiate= true;//ÿ��ȡһ��ˢ��һ��ͼ��
    }
}
