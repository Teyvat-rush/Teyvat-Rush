using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ailin : MonoBehaviour
{
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
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().ChangeHealth(-other.GetComponent<Enemy>().health);//��ɱǰһ�е���
        }
    }
    //public void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        other.GetComponent<Enemy>().ChangeHealth(-other.GetComponent<Enemy>().health);//��ɱǰһ�е���
    //    }
    //}
    public void MyDestroy()
    {
        Destroy(gameObject);
    }
}
