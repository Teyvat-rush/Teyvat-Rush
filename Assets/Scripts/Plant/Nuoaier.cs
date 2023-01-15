using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class Nuoaier : Plant
{
  private SpriteRenderer sr;
  public Sprite[] pic;
    // Start is called before the first frame update
    protected override  void Start()
    {
    base.Start();
    sr = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
    base.Update();
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
