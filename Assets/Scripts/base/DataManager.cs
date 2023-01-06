using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DataManager : MonoBehaviour
{
  public static DataManager instance;
  public Coin coin = new Coin();
  public Likability likability = new Likability();
  public Characters_Likability Characters_Likability_List = new Characters_Likability();
  Likability Wendi;
  Likability Mona;
  Likability Nuoaier;
  Likability Abeiduo;
  Likability Anbo;
  Likability Diaona;
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
    string json_Likability = JsonUtility.ToJson(DataManager.instance.likability);
    string json_Mora = JsonUtility.ToJson(DataManager.instance.coin);
    string filepath_Likability = Application.streamingAssetsPath + "/Likability.json";
    string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
    using (StreamWriter streamWriter = new StreamWriter(filepath_Mora))
    {
      streamWriter.WriteLine(json_Mora);
      streamWriter.Close();
      streamWriter.Dispose();
    }
    using (StreamWriter streamWriter = new StreamWriter(filepath_Likability))
    {
      streamWriter.WriteLine(json_Likability);
      streamWriter.Close();
      streamWriter.Dispose();
    }
  }
  void LoadData()
  {
    string json_Likability = JsonUtility.ToJson(DataManager.instance.likability);
    string json_Mora = JsonUtility.ToJson(DataManager.instance.coin);
    string filepath_Likability = Application.streamingAssetsPath + "/Likability.json";
    string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
    using (StreamReader streamReader = new StreamReader(filepath_Mora))
    {
      json_Mora = streamReader.ReadToEnd();
      streamReader.Close();
    }
    using (StreamReader streamReader = new StreamReader(filepath_Likability))
    {
      json_Likability = streamReader.ReadToEnd();
      streamReader.Close();
    }
    DataManager.instance.coin = JsonUtility.FromJson<Coin>(json_Mora);
    DataManager.instance.likability = JsonUtility.FromJson<Likability>(json_Likability);
  }
}
