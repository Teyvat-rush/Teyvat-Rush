using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="DATA",order =1)]
public class Data : ScriptableObject
{
    public List<Data> AllData = new List<Data>();
  public int Moranum;
}
