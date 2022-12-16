using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProducedSun : MonoBehaviour
{

    public float g = -4;//�������ٶȣ�������Ϊy��������
    public float vy0 = 2;//��ֱ������ٶȣ�������Ϊy��������
    public float v_Inflation = 0.5f; //�����ٶ�
    private Rigidbody2D rb;
    private Animator am;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        am= GetComponent<Animator>();
        rb.velocity = new Vector2(Random.Range(-0.4f, 1.6f), vy0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.transform.localPosition.y<-0.45)
        {
            rb.velocity = new Vector2(0,0);
            
        }else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + g * Time.deltaTime);
        }

        if(transform.localScale.x<1)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime *v_Inflation, transform.localScale.y + Time.deltaTime *v_Inflation);
        }
        am.SetFloat("vx",rb.velocity.x);
        am.SetFloat("vy",rb.velocity.y);
    }
}
