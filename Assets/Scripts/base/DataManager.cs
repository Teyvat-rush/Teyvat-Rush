using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DataManager : MonoBehaviour
{
  public static DataManager instance;
  public Coin coin = new Coin();
  // Start is called before the first frame update
  private void Awake()
  {
    instance = this;
  }
  void Start()
    {
    LoadData();
    }

    // Update is called once per frame
    void Update()
    {
    SaveData();
    }
  void SaveData()
  {
    string json = JsonUtility.ToJson(DataManager.instance.coin);
    string filepath = Application.streamingAssetsPath + "/Mora.json";
    using (StreamWriter streamWriter = new StreamWriter(filepath))
    {
      streamWriter.WriteLine(json);
      streamWriter.Close();
      streamWriter.Dispose();
    }
  }
  void LoadData()
  {
    string json = JsonUtility.ToJson(DataManager.instance.coin);
    string filepath = Application.streamingAssetsPath + "/Mora.json";
    using (StreamReader streamReader = new StreamReader(filepath))
    {
      json = streamReader.ReadToEnd();
      streamReader.Close();
    }
    DataManager.instance.coin = JsonUtility.FromJson<Coin>(json);
  }
}
