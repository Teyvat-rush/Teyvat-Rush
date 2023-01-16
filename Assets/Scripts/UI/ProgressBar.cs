using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Text LevelName;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject flag;
    public static bool initialize=false;
    
    public static List<GameObject> Flags=new List<GameObject>();
    private float d = 0f;//左右距离
    public float targetValue = 0f;
    void Start()
    {
        d = rightPoint.transform.position.x - leftPoint.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initialize)
        {
            slider.value = 0f;
            targetValue = 0f;
            LevelName.text = GameManager.LevelNames[GameManager.curLevelID];
            float waves = LevelData.Levels[GameManager.curLevelID][0].ProgressID_max;//本关旗子数
            //Debug.Log("d = " + d);
            Flags.Clear();
            for(float i=0f;i<waves;i+=1)//自动生成旗子
            {
                Flags.Add(Instantiate(flag,flag.transform.position,flag.transform.rotation));
                Flags[(int)i].transform.parent = leftPoint.transform;
                Flags[(int)i].transform.localScale = new Vector3(-2, 2, 1);
                Flags[(int)i].transform.localPosition = new Vector3((waves-1-i)*d/waves*100f, 0, 0);
                Debug.Log("旗子横坐标x=" + d * i *100/ waves * 1f);
            }
            initialize = false;
        }
        if(GameManager.gameStart)
        {
            if(targetValue!=1)
            {
                targetValue = LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].ProgressID / LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].ProgressID_max + LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].TimeID / LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].TimeID_max / LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].ProgressID_max;
                //Debug.Log("ProgressID= " + LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].ProgressID);
                //Debug.Log("ProgressID_max= " + LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].ProgressID_max);
                //Debug.Log("TimeID= " + LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].TimeID);
                //Debug.Log("TimeID_max= " + LevelData.Levels[GameManager.curLevelID][GameManager.totalCreatedNum].TimeID_max);
                //Debug.Log("targetValue= " + targetValue);
            }
            if ((targetValue<=1)&&(slider.value<targetValue))
            {
                slider.value += 0.002f;
            }
        }
    }
}
