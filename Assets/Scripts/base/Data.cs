using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="DATA",order =1)]
public class Data : ScriptableObject
{
    public List<Data> AllData = new List<Data>();
  public int Moranum;
}
[System.Serializable]
public class Coin
{
  public int num;
}
[System.Serializable]
public class Likability
{
  public string name;
  public bool locked;
  public int num;
  public int level;
}
public class Characters_Likability
{
  public List<Likability> Likabilities = new List<Likability>();
}
