using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class MoraBag : MonoBehaviour
{
    public Text text_Mora;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //¶ÁÄ¦À­Êý¾Ý
        //string json_Mora = JsonUtility.ToJson(DataManager.instance.coin);
        //string filepath_Mora = Application.streamingAssetsPath + "/Mora.json";
        //using (StreamReader streamReader = new StreamReader(filepath_Mora))
        //{
        //    json_Mora = streamReader.ReadToEnd();
        //    streamReader.Close();
        //}
        text_Mora.text = GameManager.gamemanagerr.mora.ToString();
    }
}
