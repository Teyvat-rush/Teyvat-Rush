using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelData : ScriptableObject
{
  public List<LevelItem> LevelDataList = new List<LevelItem>();
}
[System.Serializable]//可序列化的类
public class LevelItem
{
  public int ID;
  public int LevelID;
  public int ProgressID;
  public int CreateTime;
  public int EnemyType;
  public int BornPos;
}
