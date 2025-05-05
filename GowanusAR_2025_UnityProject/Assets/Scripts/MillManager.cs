using System.Collections;
using System.Collections.Generic;
using CesiumForUnity;
using Unity.VisualScripting;
using UnityEngine;

public class MillManager : MonoBehaviour
{

    public AudioSource voiceover;

    public AudioClip[] clips;

    int count = 0;

    bool cubeHit = false;

    public GameObject cube;
    public Transform cubePos;

    float time = 0f;

    bool bool2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(time<=5f){
            time+=Time.deltaTime;
            Debug.Log(time);
        }else if(!bool2){
            Instantiate(cube, cubePos.position, Quaternion.identity);
            Debug.Log("yes");
            bool2 = true;
        }
        
        if(time == 5f){
            
            
        }

        if(cubeHit)
        {
            if(!voiceover.isPlaying && count < 6){
                Instantiate(cube, cubePos.position, Quaternion.identity);
                cubeHit = false;
            }

        }
    }

    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Object"){
            Destroy(c.gameObject);
            voiceover.clip = clips[count];
            voiceover.Play();
            //voiceover.PlayOneShot(clips[count]);
            cubeHit = true;
            count += 1;
        }


    }
}
