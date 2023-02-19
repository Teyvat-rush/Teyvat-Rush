using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Button_Reward : MonoBehaviour
{
    public GameObject disappearParticle;
    public GameObject panelSucceed;
    public GameObject buttonPause;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(CreateDisappearParticle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateDisappearParticle()
    {
        Canvas_LibraryOfEnemy.checkMode = 1;
        GameManager.curLevelID++;///////////主线进度+1
        GameManager.gamemanagerr.curLevelID++;
        string json = JsonUtility.ToJson(GameManager.gamemanagerr, true);
        File.WriteAllText(Application.streamingAssetsPath + "/GameManagerr.json", json);
        Instantiate(disappearParticle,transform.position,transform.rotation);
        
        panelSucceed.SetActive(true);
        buttonPause.SetActive(false);
        gameObject.SetActive(false);
    }
}
