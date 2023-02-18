using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public GameObject panel_Pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.gameStart&&!GameManager.gameEnd)
            {
                if (panel_Pause.activeSelf)
                {
                    
                }
                else
                {
                    panel_Pause.SetActive(true);
                }
            }
        }
    }
}
