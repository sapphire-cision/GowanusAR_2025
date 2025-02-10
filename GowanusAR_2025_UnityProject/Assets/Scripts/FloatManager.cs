using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatManager : MonoBehaviour
{

    Vector3 from = new Vector3(0,0,0);
    Vector3 to = new Vector3(0,0,0);

    //Quaternion from = Quaternion.Euler(0f,0f,0f);
    //Quaternion to = Quaternion.Euler(0f,0f,0f);
    float speed = 0.2f;
    float timeCount = 5.1f;

    private float fromY = 0;

    private float fromY_OG = 0;

    private float toY = 0;

    //public GameObject[] buoys;
    public GameObject raft;

    // Start is called before the first frame update
    void Start()
    {

        fromY = raft.transform.localPosition.y;
        fromY_OG = raft.transform.localPosition.y;

        toY = raft.transform.localPosition.y;

        /*from = buoys[0].transform.localPosition;

        fromY = buoys[0].transform.position.y;
        
        to = buoys[0].transform.localPosition;

        toY = buoys[0].transform.position.y;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount < 5)
        {
            Vector3 newFrom = new Vector3(raft.transform.localPosition.x, fromY, raft.transform.localPosition.z);

            Vector3 newTo = new Vector3(raft.transform.localPosition.x, fromY_OG + toY, raft.transform.localPosition.z);

            raft.transform.localPosition = Vector3.Lerp(newFrom, newTo, timeCount * speed); //* speed

        }
        else
        {
            timeCount = 0f;


            fromY = raft.transform.localPosition.y;

            toY = Random.Range(-0.1f, 0.1f);


            
        }

        timeCount = timeCount + 0.02f;


        /*if( timeCount < 1){ //to != from
        for (int x=0;x<buoys.Length;x++){
                Vector3 newFrom = new Vector3(buoys[x].transform.position.x, fromY, buoys[x].transform.position.z);

                Vector3 newTo = new Vector3(buoys[x].transform.position.x, toY, buoys[x].transform.position.z);

                buoys[x].transform.localPosition = Vector3.Lerp(newFrom, newTo, timeCount); //* speed
            }

            //Debug.Log("still going");
        }else{
            timeCount = 0f;


            //from = this.transform.localPosition;

            fromY = buoys[0].transform.position.y;


            toY = Random.Range(-0.5f, 0.5f);

            //to = new Vector3(this.transform.localPosition.x, Random.Range(-0.5f, 0.5f), this.transform.localPosition.z);



            //Quaternion.Euler(new Vector3(this.transform.rotation.eulerAngles.x, Random.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z));
            //Debug.Log("we done");
        }

        timeCount = timeCount + 0.02f; //Time.deltaTime;*/
    }
}
