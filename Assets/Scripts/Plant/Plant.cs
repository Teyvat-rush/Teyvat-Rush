using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
  public float health = 100;
  public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
    currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public float ChangeHealth(float num)
  {
    currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
    if (currentHealth <= 0)
    {
      GameObject.Destroy(gameObject);
    }
    return currentHealth;
  }
}
