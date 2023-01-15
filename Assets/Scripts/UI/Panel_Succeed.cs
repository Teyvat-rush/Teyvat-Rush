using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Panel_Succeed : MonoBehaviour
{
    public GameObject button_NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        button_NextLevel.GetComponent<Button>().onClick.AddListener(GoToNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
