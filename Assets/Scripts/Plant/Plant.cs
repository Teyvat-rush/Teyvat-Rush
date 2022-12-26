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
      if(this.name== "Point_Wendi")
      {
        int i = Random.Range(1, 4);
        SoundManager.instance.PlaySound(Globals.WendiDie + i.ToString());
      }
        GameObject.Destroy(gameObject);
    }
    return currentHealth;
    }
}
