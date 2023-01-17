using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPile : MonoBehaviour
{
    public GameObject ailin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            GameObject Ailin =Instantiate(ailin, gameObject.transform.parent);
            Ailin.SetActive(true);
            Destroy(gameObject);
            //other.GetComponent<Enemy>().ChangeHealth(-other.GetComponent<Enemy>().health);//秒杀前一列敌人
        }
    }
}
