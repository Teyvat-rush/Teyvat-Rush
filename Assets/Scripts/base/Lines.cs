using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
  public GameObject line0;
  public GameObject line1;
  public GameObject line2;
  public GameObject line3;
  public GameObject line4;
  // Start is called before the first frame update
  void Start()
    {
    if(GameManager.curLevelID>=2)
    {
      line0.SetActive(true);
      line1.SetActive(true);
      line2.SetActive(true);
      line3.SetActive(true);
      line4.SetActive(true);
    }
    else if(GameManager.curLevelID>=1)
    {
      line0.SetActive(false);
      line1.SetActive(true);
      line2.SetActive(true);
      line3.SetActive(true);
      line4.SetActive(false);
    }
    else
    {
      line0.SetActive(false);
      line1.SetActive(false);
      line2.SetActive(true);
      line3.SetActive(false);
      line4.SetActive(false);
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
