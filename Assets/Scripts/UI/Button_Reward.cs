using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        GameManager.curLevelID++;///////////主线进度+1
        Instantiate(disappearParticle,transform.position,transform.rotation);
        gameObject.GetComponent<Animator>().SetBool("IsOK", true);
        panelSucceed.SetActive(true);
        buttonPause.SetActive(false);
        gameObject.SetActive(false);
    }
}
