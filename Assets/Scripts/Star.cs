using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
  public float duration;//持续时间
  private float timer;//计时器
  private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();
    timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    SwitchAnim();
    }

  void SwitchAnim()
  {
    if (anim.GetBool("idle"))
    {
      timer += Time.deltaTime;
      if (timer >= duration)
      {
        timer = 0;
        anim.SetBool("Disappear",true);
      }
    }
  }
  public void Disappearing()
  {
    GameObject.Destroy(gameObject);
  }
  private void OnMouseDown()
  {
    anim.SetBool("Disappear", true);
    GameManager.instance.ChangeStarNum(25);
  }
}
