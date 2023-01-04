using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Reward : MonoBehaviour
{
    public GameObject disappearParticle;
    public GameObject panelSucceed;
    public GameObject buttonPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateDisappearParticle()
    {
        Instantiate(disappearParticle,transform.position,transform.rotation);
        panelSucceed.SetActive(true);
        buttonPause.SetActive(false);
        gameObject.SetActive(false);
    }

}
