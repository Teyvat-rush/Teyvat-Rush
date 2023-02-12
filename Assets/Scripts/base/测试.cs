//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//public class 测试 : MonoBehaviour
//{
//  public Enemyy enemyy = new Enemyy();
//    // Start is called before the first frame update
//    void Start()
//    {
    
//    LoadData();
//  }
//    // Update is called once per frame
//    void Update()
//    {
//    //string json = JsonUtility.ToJson(enemyy, true);
//    //string path = Application.streamingAssetsPath + "/test.json";
//    //using (StreamWriter streamWriter = new StreamWriter(path))
//    //{
//    //  streamWriter.WriteLine(json);
//    //  streamWriter.Close();
//    //  streamWriter.Dispose();
//    //}
//    SaveData();
//  }
//  void SaveData()
//  {
//    string json = JsonUtility.ToJson(enemyy, true);
//    File.WriteAllText(Application.streamingAssetsPath + "/测试.json", json);
//  }
//  void LoadData()
//  {
//    string json = File.ReadAllText(Application.streamingAssetsPath + "/测试.json");
//    Enemyy enemyy = new Enemyy();
//    enemyy = JsonUtility.FromJson<Enemyy>(json);
//  }
//}
