using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelData : ScriptableObject
{
    public static List<List<LevelItem>> Levels = new List<List<LevelItem>>();
    public static List<LevelItem> LevelDataList = new List<LevelItem>();
    public static List<int> totalNums= new List<int>();
}
[System.Serializable]//可序列化的类
public class LevelItem
{
    //public int ID;
    //public int LevelID;
    public float ProgressID_max;
    public float ProgressID;
    public float TimeID;
    public float TimeID_max;
    public float CreateTime;
    public int EnemyType;
    public int Ran0;
    public int Ran1;
    public int Ran2;
    public int Ran3;
    public int Ran4;
    public int Ran5;
    public int lines;
    
}
