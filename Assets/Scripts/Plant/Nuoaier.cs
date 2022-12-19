using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class Nuoaier : Plant
{
  private SpriteRenderer sr;
  public Sprite[] pic;
    // Start is called before the first frame update
    void Start()
    {
    sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    if (currentHealth <= health/2)
    {
      sr.sprite = pic[0];
    }
    if(currentHealth<=health/5)
    {
      sr.sprite = pic[1];
    }
    }
  
}
