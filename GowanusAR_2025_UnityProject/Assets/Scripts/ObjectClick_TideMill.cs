using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;


public class ObjectClick_TideMill : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(this.gameObject);
        //numGen.ReleaseObject(this.gameObject);

        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
