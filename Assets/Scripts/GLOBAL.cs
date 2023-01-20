//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class GLOBAL : MonoBehaviour
//{
//    public  int i = 0;
//    public GameObject buttonAdd;
//    public GameObject loaded;
//    // Start is called before the first frame update
//    void Start()
//    {
//        buttonAdd.GetComponent<Button>().onClick.AddListener(Add);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.A))
//        {
//            ES3.Save("myGameObject", this.gameObject);
//        }
        
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            Debug.Log("¶ÁÈ¡Êý¾Ý");
//            loaded = ES3.Load<GameObject>("myGameObject");
//            //loaded.transform.parent = gameObject.transform.parent;
//            //this.gameObject.SetActive(false);
//        }
//    }
//    public void Add()
//    {
//        buttonAdd.transform.GetChild(0).gameObject.GetComponent<Text>().text = i.ToString();
//        i++;
//    }
//}
