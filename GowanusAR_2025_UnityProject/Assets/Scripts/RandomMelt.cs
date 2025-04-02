using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using com.zibra.liquid.Manipulators;
using com.zibra.liquid.DataStructures;

public class RandomMelt : MonoBehaviour
{

    private float time = 0f;


    private float meltTime;

    private bool lerpMelt;

    //private float interpolationRatio;

    private float speed = 0f;

    public ZibraLiquidForceField forceField;
    public ZibraLiquidSolverParameters zibraLiquidSolverParameters;

    private float meltDur = 0f;

    public bool beginMeltCycle = false;


    // Start is called before the first frame update
    void Start()
    {
        meltTime = Random.Range(5f, 10f);
    }

    public void BeginMeltCycle(){
        beginMeltCycle = true;
    }

    public void EndMeltCycle(){
        beginMeltCycle = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(beginMeltCycle){

            

            if (time >= meltTime)
            {
                time = 0f;
                meltTime = Random.Range(5f, 10f);

                lerpMelt = true;

                //zibraLiquidSolverParameters.Gravity = new Vector3(0, Random.Range(-20,0), 0);

                forceField.DistanceOffset = Random.Range(-5, -2);

                forceField.DistanceDecay = 0.7f;

                forceField.GetComponent<ZibraLiquidEmitter>().enabled = false;

                meltDur = Random.Range(1,1.5f);

                Debug.Log("melted");

            }


            

        }


        if (lerpMelt && time < meltDur/*1.5f*/)
        {

            //this.transform.localScale = Vector3.Lerp(new Vector3(1.61375f, 2.61375f, 1.61375f), new Vector3(1f, 1f, 1f), time);
            forceField.Strength = Mathf.Lerp(2f, 0.05f, time*2);

            //this.transform.localScale = Vector3.Lerp(new Vector3(2.61375f, 2.61375f, 2.61375f), new Vector3(1f, 2.61375f, 1f), time);
            this.transform.localScale = new Vector3(1f, 2.61375f, 1f);

        }
        else if (lerpMelt && time >= meltDur && time < 3f)
        {
            

            this.transform.localScale = new Vector3(2.61375f, 2.61375f, 2.61375f);

            //zibraLiquidSolverParameters.Gravity = new Vector3(0, 0, 0);

            //this.transform.localScale = Vector3.Lerp(new Vector3(1.61375f, 2.61375f, 1.61375f), new Vector3(2.61375f, 2.61375f, 2.61375f), time);
            forceField.Strength = Mathf.Lerp(0.25f, 2f, time/3);

            forceField.DistanceOffset = 0;

            //forceField.GetComponent<ZibraLiquidEmitter>().enabled = true;


        }
        else if (lerpMelt && time >= 3f)
        {
            Debug.Log("finished melt");

            //this.transform.localScale = new Vector3(2.61375f, 2.61375f, 2.61375f);
            forceField.Strength = 2;

            forceField.DistanceDecay = 0.01f;

            forceField.GetComponent<ZibraLiquidEmitter>().enabled = true;

            lerpMelt = false;

            
        }
        


        /*if (lerpMelt && time < 0.5f)
        {

            this.transform.localScale = Vector3.Lerp(new Vector3(2.61375f, 2.61375f, 2.61375f), new Vector3(1f, 1f, 1f), time);

        }
        else if (lerpMelt && time >= 0.5f)
        {
            Debug.Log("finished melt");

            //this.transform.localScale = new Vector3(2.61375f, 2.61375f, 2.61375f);

            this.transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(2.61375f, 2.61375f, 2.61375f), time);
        }
        else if (lerpMelt && time >= 1f)
        {

            this.transform.localScale = new Vector3(2.61375f, 2.61375f, 2.61375f);


            lerpMelt = false;
        }*/
    }

    public void MeltFigure(){
        time = 0f;
        meltTime = Random.Range(5f, 10f);

        lerpMelt = true;

        //zibraLiquidSolverParameters.Gravity = new Vector3(0, Random.Range(-20,0), 0);

        forceField.DistanceOffset = Random.Range(-5, -2);

        forceField.DistanceDecay = 0.7f;

        forceField.GetComponent<ZibraLiquidEmitter>().enabled = false;

        meltDur = Random.Range(1,1.5f);

        Debug.Log("melted");
    }

}
