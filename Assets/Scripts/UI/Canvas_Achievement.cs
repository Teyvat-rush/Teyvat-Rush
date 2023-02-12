using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Achievement : MonoBehaviour
{
    public GameObject panel_Achievements;
    public GameObject panel_RewardIndex;
    public Text text_AchievedNum;
    public Text text_Indexs;
    public static List<Button> button_Attain=new List<Button>();//ȫ��δδ��ɳɾ͵���ȡ��ť
    public static List<Transform> notAchieved = new List<Transform>();//ȫ��δ��ɳɾ͵�λ��
    public static List<int> index_2 = new List<int>();//δ����б��еĳɾ���ţ���ʼ״̬��0��λ�õĳɾ����Ϊ0���Դ�����
    public static List<int> progress = new List<int>();
    public static List<int> target=new List<int>();
    public static List<bool> AchieveState = new List<bool>();//���ɾʹ��״̬
    public static int ALLAchievedNum;
    public static int achievedNum;
    public static bool isFirst=true;
    public bool isRemainingReward;//true:�н���û��ȡ
    public static bool initialize = true;
    // Start is called before the first frame update
    public void Awake()
    {
        ALLAchievedNum = 2;//////////�ֶ������ܳɾ͸���

        if (isFirst)////////////�Ƿ��״ν�����Ϸ
        {
            Debug.Log("Canvas_Achievement initialize: IsFirst");

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
                //Debug.Log(temp_1+"  "+temp_2);
                button_Attain[i].onClick.RemoveAllListeners();
                button_Attain[i].onClick.AddListener(delegate{AttainedMove(temp_1,temp_2);});
            }
            isFirst = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initialize) 
        {
            Debug.Log("Canvas_Achievement initialize:button_Attained.Count = " +button_Attain.Count);

            text_Indexs.text = "";
            isRemainingReward = false;
            for (int i = 0; i < ALLAchievedNum; i++)
            {
                notAchieved[i] = panel_Achievements.transform.GetChild(i);
                button_Attain[i] = notAchieved[i].GetChild(4).GetComponent<Button>();
                button_Attain[i].onClick.RemoveAllListeners();
                int temp_1 = i;//ͼ���е�λ��
                int temp_2 = i;//�ɾ����
                button_Attain[i].onClick.AddListener(delegate { AttainedMove(temp_1, temp_2); });
                if (button_Attain[i] != null)
                {
                    button_Attain[i].gameObject.transform.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = progress[i].ToString();
                    if (progress[i] >= target[i] && AchieveState[i] == false)
                    {
                        isRemainingReward = true;
                        button_Attain[i].gameObject.SetActive(true);
                        button_Attain[i].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                        text_Indexs.text += " ";
                        text_Indexs.text += i.ToString();
                    }
                }
                if (AchieveState[i])
                {
                    button_Attain[i].gameObject.SetActive(true);
                    button_Attain[i].interactable = false;
                    button_Attain[i].gameObject.transform.GetChild(0).GetComponent<Text>().text = "����ȡ";
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
            text_AchievedNum.text = achievedNum.ToString();
            initialize= false;
        }
        
    }
    
    public void AttainedMove(int n1,int n2)
    {
        SoundManager.instance.PlaySound(Globals.Attain0);

        //Debug.Log("1");
        achievedNum++;
        button_Attain[n2].interactable = false;
        //Debug.Log("1");
        button_Attain[n2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "����ȡ";
        button_Attain[n2].gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
        //Debug.Log("1");
        AchieveState[n2] = true;
        initialize= true;//ÿ��ȡһ��ˢ��һ��ͼ��
        GameManager.gamemanagerr.mora += int.Parse(button_Attain[n2].gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text);
        string json = JsonUtility.ToJson(GameManager.gamemanagerr, true);
        File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json);
        //string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
        //using (StreamWriter streamWriter = new StreamWriter(filepath_Mora))
        //{
        //    streamWriter.WriteLine(json_Mora);
        //    streamWriter.Close();
        //    streamWriter.Dispose();
        //}
    }
}
