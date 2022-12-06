using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
  public Vector3 Direction;
  public float Speed;
    void Start()
    {
        
    }

    void Update()
    {
    transform.position += Direction* Speed * Time.deltaTime;
    }
}
