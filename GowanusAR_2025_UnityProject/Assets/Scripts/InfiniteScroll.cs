using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public float speedMultiplier = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RawImage>().uvRect = new Rect(this.GetComponent<RawImage>().uvRect.x + speedMultiplier, this.GetComponent<RawImage>().uvRect.y, this.GetComponent<RawImage>().uvRect.width, this.GetComponent<RawImage>().uvRect.height);

    }
}
