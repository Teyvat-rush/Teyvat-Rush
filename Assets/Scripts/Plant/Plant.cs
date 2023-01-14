using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
  public bool ShootAwake;
  public float health = 100;
  public float currentHealth;
  public bool PlantAwake;
  protected Rigidbody2D rb;
  protected Collider2D coll;
  protected Animator animator;
  // Start is called before the first frame update
  protected virtual void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<Collider2D>();
    animator = GetComponent<Animator>();
    currentHealth = health;
    
    PlantAwake = false;
    
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(PlantAwake)
    {
      animator.speed = 1;
      coll.enabled = true;
    }
    else
    {
      animator.speed = 0;
      coll.enabled = false; 
    }
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
      if (this.name == "Point_Mona")
      {
        int i = Random.Range(1, 4);
        SoundManager.instance.PlaySound(Globals.MonaDie + i.ToString());
      }
      if (this.name == "Point_Nuoaier")
      {
        int i = Random.Range(1, 4);
        SoundManager.instance.PlaySound(Globals.NuoaierDie + i.ToString());
      }
      GameObject.Destroy(gameObject);
    }
    return currentHealth;
    }
}
