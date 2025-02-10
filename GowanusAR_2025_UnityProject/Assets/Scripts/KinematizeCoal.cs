using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematizeCoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {

        if(c.gameObject.tag == "Coal")
        {
            //c.GetComponent<Rigidbody>().isKinematic = true;
            //c.GetComponent<Rigidbody>().useGravity = false;
            c.GetComponent<Rigidbody>().mass = 5000;

        }

    }
}
