using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Start is called before the first frame update
  public static GameManager instance;
  public int starNum;
    void Start()
    {
    instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void ChangeStarNum(int ChangeNum)
    {
    starNum += ChangeNum;
        if(starNum<=0)
        {
      starNum = 0;
        }
    }
}
