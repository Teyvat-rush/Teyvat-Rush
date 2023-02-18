using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HydroAbyssMage : MonoBehaviour
{
    public GameObject BingElement;
    // Start is called before the first frame update
    void Start()
    {
        GameObject b = Instantiate(BingElement, transform.position, transform.rotation, gameObject.transform);
        b.GetComponent<SpriteRenderer>().sortingLayerName = "Plants";
        b.GetComponent<SpriteRenderer>().sortingOrder = 70;
        b.transform.localPosition = new Vector3(0, 0.7f, 0);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
