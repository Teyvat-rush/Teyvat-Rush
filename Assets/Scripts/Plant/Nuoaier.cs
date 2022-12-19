using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class NewBehaviourScript : Plant
{
  private SpriteRenderer sr;
  public Sprite target;
    // Start is called before the first frame update
    void Start()
    {
    sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    ChangetheImage();
    }
  private void ChangetheImage()
  {
    if(currentHealth<=health/2)
    {
      sr.sprite = target;
    }
  }
}
