using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using com.zibra.liquid.Manipulators;

public class IndustryManager : MonoBehaviour
{
    public int count = -1;

    public GameObject phase1;
    public GameObject phase3;

    public GameObject button;

    public GameObject beginButton;

    public float time = 0f;

    public AudioClip[] clips;
    public AudioSource audio;

    //public GameObject powerhouseBuilding;
    public Transform bargePos;
    public GameObject barge;
    public GameObject barge0_v2;
    //public GameObject truck;

    public Animator gaiaAnim;

    public GameObject gaia2;
    public GameObject gaia2_v2;
    public GameObject gaia2_v3;
    public GameObject jointPivot2;
    public GameObject coal;
    public GameObject coalPrefab;
    public AudioSource gaiaVoice2;

    public GameObject gaia2Emit;

    public MeshRenderer gaia2Mat;
    public MeshRenderer gaia3Mat;

    bool craneRise = false;

    public bool waitCoalDrop = false;
    bool waitCoalDrop2 = false;
    bool waitCoalDrop3 = false;

    public GameObject leftShoulder;

    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject building2;
    public GameObject building2Smoke;
    public GameObject building3;

    private bool showSkyline1 = false;

    private bool showBarge1 = false;
    public GameObject skyline1;

    public GameObject muck;

    public GameObject raft;

    public GameObject industryVoid;

    public GameObject gaiaBod;

    public Material[] materials;
    public GameObject gaiaArmature;

    public Animator canalAnim;
    public Animator armAnim;

    private bool checkGaiaAudio2 = false;

    private bool playCanal = false;
    private bool playArm = false;

    private bool evap1 = false;
    //private bool evap1 = true;

    private bool waitToPlay2ndClip = false;

    public GameObject coalHeaps;
    public GameObject coalDock;

    // Phase 3

    public GameObject gaiaGas;

    public GameObject barge2;
    public GameObject barge3;
    public GameObject barge4;
    public GameObject barge5;

    bool checkGaiaAudio3 = false;

    // Phase 4

    public GameObject innerFlame;

    public GameObject skyline2;

    bool checkGaiaAudio4 = false;

    // Phase 5

    private bool phase5Intro = false;

    private bool phase5CraneIntro = false;

    bool checkGaiaAudio5 = false;

    public GameObject jointPivot3;

    public GameObject gaia3;

    public GameObject remBarge;

    private bool firstMuck = false;
    private bool secondMuck = false;

    public GameObject muckEmit;

    public GameObject toxin1Loc;
    public GameObject toxin2Loc;
    public GameObject toxin3Loc;
    public GameObject toxin1Loc2;
    public GameObject toxin2Loc2;
    public GameObject toxin3Loc2;
    public GameObject toxin1;
    public GameObject toxin2;
    public GameObject toxin3;

    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;


    public AudioSource gaiaVoice3;


    // Phase 6

    bool checkGaiaAudio6 = false;

    public GameObject industrialSkyline3;



    // Phase 7

    bool checkGaiaAudio7 = false;

    bool startFinalCoal = false;
    bool startFinalCoal2 = false;
    public GameObject finalCoal;

    public GameObject miniCanal;
    bool showMiniCanal = false;

    // Start is called before the first frame update
    void Start()
    {
        //count = 3;
        //NextUp();

        if(phase1.activeSelf)
            phase1.SetActive(false);
        

        // Keep a note of the time the movement started.
        //startTime = Time.time;

        
        
    }

    public void ShrinkLeftArm(){
        leftShoulder.transform.localScale = new Vector3(0, 0, 0);
    }

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    private Quaternion startRotation;
    private Quaternion endRotation;

    // Movement speed in units per second.
    public float speed = 0.2f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private bool transit1 = false;

    private float rotationMultiplier = 3f;

    private Quaternion ogRot;

    int rotCount = 0;

    //public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public Vector3 targetScale = new Vector3(200f, 200f, 0.06f);

    private Vector3 startScale;

    public Transform itemParentScale;
    

    public void TransitionItem1(){

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        startTime = Time.time;

        transit1 = true;

        startRotation = startMarker.rotation;

        //startScale = itemParentScale.localScale;
        startScale = miniCanal.transform.localScale;
        

        //startRotation = transform.rotation;
        Vector3 endEulerAngles = startRotation.eulerAngles + Vector3.up * (360f * rotationMultiplier);
        //endMarker.rotation = Quaternion.Euler(endEulerAngles);


        //endRotation = endMarker.rotation;
        endRotation = Quaternion.Euler(endEulerAngles);

        ogRot = startRotation;


        Debug.Log(startRotation);
        Debug.Log(endRotation);


    }



    // Update is called once per frame
    void Update()
    {

        if(transit1){
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            //itemParentScale.localScale = Vector3.Lerp(startScale, targetScale, fractionOfJourney);
            miniCanal.transform.localScale = Vector3.Lerp(startScale, targetScale, fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            miniCanal.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            /*miniCanal.transform.rotation = Quaternion.Lerp(startRotation, endRotation, fractionOfJourney);

            if(miniCanal.transform.rotation == endRotation && rotCount < 3){
                rotCount++;

                //miniCanal.transform.rotation = startRotation;
                miniCanal.transform.rotation = ogRot;
            }*/
        
            //Debug.Log("test");
        }


        if(phase1.activeSelf)
            time += Time.deltaTime;

        /*
        if (playCanal == false && time > 5f)
        {
            //canalAnim.Play("Base Layer.CanalFadeIn");
            canalAnim.gameObject.SetActive(true);
            canalAnim.enabled = true;
            Debug.Log("test");
            playCanal = true;
        }*/

        /*
        if (showSkyline1 == false && time > 17f)
        {
            skyline1.SetActive(true);
            showSkyline1 = true;


            //canalAnim.Play("Base Layer.ArmMoveIntoPlace");
            armAnim.enabled = true;

            raft.SetActive(false);
            armAnim.transform.gameObject.GetComponent<FloatManager>().enabled = false;

            leftShoulder.transform.localScale = new Vector3(0, 0, 0);

            //armAnim.gameObject.GetComponent<AudioSource>().time = 3;
            armAnim.gameObject.GetComponent<AudioSource>().enabled = true;
            Debug.Log("hi");



        }
        */

        /*
        if (showBarge1 == false && time > 20.5f)
        {
            barge.SetActive(true);
            showBarge1 = true;

            
        }*/

        /*
        if(showMiniCanal == false && time > 21.5f){
            showMiniCanal = true;
            miniCanal.SetActive(true);
        }*/

        /*
        if (playArm == false && time > 30f)
        {


            button.SetActive(true);

            Debug.Log("button yo");

            playArm = true;

        }
        */
        



        /*
        if (count == 0 && time > 17f && !beginButton.activeSelf)
        {
            button.SetActive(true);
        }
        else if (count == 1 && time > 9f)
        {
            button.SetActive(true);

        }
        else if (count == 2 && time > 12f)
        {
            button.SetActive(true);
        }
        else if (count == 3 && time > 14f)
        {
            button.SetActive(true);
        }
        else if (count == 4 && time > 34f)
        {
            button.SetActive(true);
        }
        */

        /*if(waitToPlay2ndClip == true && time < 1)
        {

        }
        else */

        if (evap1 == true && time >= 2)
        {
            //audio.Play();
            gaia2.SetActive(true);
            jointPivot2.SetActive(true);
            gaiaAnim.gameObject.SetActive(false);
            waitToPlay2ndClip = false;



            //waitCoalDrop = true;
            time = 0f;

            evap1 = false;

            craneRise = true;
        }

        if (craneRise == true && time >= 2)
        {

            jointPivot2.GetComponent<Animator>().Play("04_Phase2_Crane1_v1", 0, 0f);

            waitCoalDrop = true;

            craneRise = false;
        }

        if (startFinalCoal == true && time >= 11)
        {
            Instantiate(coalPrefab, finalCoal.transform.position, finalCoal.transform.rotation);
            startFinalCoal = false;
            startFinalCoal2 = true;

            time = 0f;
        }

        if (startFinalCoal == true && time >= 14)
        {
            Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
            Instantiate(coalPrefab, finalCoal.transform.position, finalCoal.transform.rotation);
            time = 0f;

        }


        if (waitCoalDrop == true && time >= 11)
        {
            Debug.Log("test");
            waitCoalDrop = false;
            //coal.transform.SetParent(null);
            Instantiate(coalPrefab, coal.transform.position, coal.transform.rotation);

            time = 0f;

            waitCoalDrop2 = true;

        }

        if (waitCoalDrop2 == true && time >= 12.25)
        {

            Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
            Instantiate(coalPrefab, coal.transform.position, coal.transform.rotation);

            time = -1.75f;

            checkGaiaAudio2 = true;

        }

        /*
        if (waitCoalDrop3 == true && time >= 11)
        {
            Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
            Instantiate(coalPrefab, coal.transform.position, coal.transform.rotation);

            time = 0f;

            //checkGaiaAudio3 = true;
            checkGaiaAudio2 = true;

        }*/


        if (checkGaiaAudio2)
        {
            if (!gaiaVoice2.isPlaying)
            {
                checkGaiaAudio2 = false;
                button.SetActive(true);
            }
        }
        else if(checkGaiaAudio3)
        {
            if (!gaiaVoice3.isPlaying)
            {
                checkGaiaAudio3 = false;
                button.SetActive(true);
            }
        }
        /*else if(checkGaiaAudio4)
        {
            if (!gaiaVoice2.isPlaying)
            {
                checkGaiaAudio4 = false;
                button.SetActive(true);
            }
        }else if(checkGaiaAudio5)
        {
            if (!gaiaVoice2.isPlaying)
            {
                checkGaiaAudio5 = false;
                button.SetActive(true);
            }
        }else if(checkGaiaAudio6)
        {
            if (!gaiaVoice2.isPlaying)
            {
                checkGaiaAudio6 = false;
                button.SetActive(true);
            }
        }else if(checkGaiaAudio7)
        {
            if (!gaiaVoice2.isPlaying)
            {
                checkGaiaAudio7 = false;
                button.SetActive(true);
            }
        }*/


        /*

        if(evap1 == true && time < 1)
        {

            gaiaArmature.transform.localScale = Vector3.Lerp(gaiaArmature.transform.localScale, new Vector3(gaiaArmature.transform.localScale.x, gaiaArmature.transform.localScale.y, 0f), time * 0.2f);

        }
        else if(evap1 == true && time >= 1)
        {
            evap1 = false;
        }*/


        if (phase5Intro && time >= 2f)
        {
            Debug.Log("phase 5!");

            gaia2.SetActive(false);
            gaia3.SetActive(true);
            jointPivot3.SetActive(true);
            remBarge.SetActive(true);

            phase5CraneIntro = true;





            phase5Intro = false;
        }
        else if (phase5CraneIntro && time >= 4f)
        {
            phase5CraneIntro = false;

            jointPivot3.GetComponent<Animator>().Play("04_Phase2_Crane1", 0, 0f);

            checkGaiaAudio3 = true;

            firstMuck = true;

            time = 0f;
        }

        if (firstMuck && time >= 9.5f && time < 11.5f)
        {
            if (!muckEmit.activeSelf)
            {
                muckEmit.SetActive(true);

                Instantiate(toxin1, toxin1Loc.transform.position, toxin1.transform.rotation);
                Instantiate(toxin2, toxin2Loc.transform.position, toxin2.transform.rotation);
                Instantiate(toxin3, toxin3Loc.transform.position, toxin3.transform.rotation);

                Instantiate(toxin1, toxin1Loc2.transform.position, toxin1.transform.rotation);
                Instantiate(toxin2, toxin2Loc2.transform.position, toxin2.transform.rotation);
                Instantiate(toxin3, toxin3Loc2.transform.position, toxin3.transform.rotation);
            }

            
        }
        else if (firstMuck && time >= 11.5f)
        {
            muckEmit.SetActive(false);
            Debug.Log("emit mucked!");
            firstMuck = false;

            secondMuck = true;

            time = 0f;
        }

        if (secondMuck && time >= 12f && time < 14f)
        {
            Debug.Log("emit mucked hyper!");
            if (!muckEmit.activeSelf)
            {
                muckEmit.SetActive(true);

                Instantiate(toxin1, toxin1Loc.transform.position, toxin1.transform.rotation);
                Instantiate(toxin2, toxin2Loc.transform.position, toxin2.transform.rotation);
                Instantiate(toxin3, toxin3Loc.transform.position, toxin3.transform.rotation);

                Instantiate(toxin1, toxin1Loc2.transform.position, toxin1.transform.rotation);
                Instantiate(toxin2, toxin2Loc2.transform.position, toxin2.transform.rotation);
                Instantiate(toxin3, toxin3Loc2.transform.position, toxin3.transform.rotation);
            }
        }
        if (secondMuck && time >= 14f)
        {
            muckEmit.SetActive(false);
            //firstMuck = false;
            Debug.Log("emit mucked 2!");
            //secondMuck = false;

            time = 0f;
        }


    }


    public void ResetTime()
    {
        time = 0f;
    }

    public void NextUp()
    {
        if (count < 7)
        {


            button.SetActive(false);

            count += 1;


            //audio.Stop();
            //audio.clip = clips[count];


            if (count != 1)
            {


                //audio.Play();
            }


            if (count == 0) {

                phase1.SetActive(true);
                phase3.SetActive(true);

            } else if (count == 1)
            {
                Debug.Log("testcount1");

                time = -1.75f;

                transit1 = false;

                coalHeaps.SetActive(true);
                coalDock.SetActive(true);


                //powerhouseBuilding.SetActive(true);
                //barge.GetComponent<Animator>().enabled = false;
                //barge.transform.localPosition = bargePos.position;
                barge.SetActive(true);
                barge0_v2.SetActive(false);

                barge2.SetActive(true);
                barge3.SetActive(true);
                barge4.SetActive(true);
                barge5.SetActive(true);

                smoke1.SetActive(true);
                smoke2.SetActive(true);
                smoke3.SetActive(true);

                //barge.SetActive(true);

                //evap1 = true;

                //gaiaAnim.enabled = true;
                //gaiaAnim.Play("GaiaMelt1", 0, 0f);
                //industryVoid.GetComponent<Animator>().enabled = true;

                //gaiaBod.GetComponent<RandomMelt>().enabled = false;


                //gaiaBod.GetComponent<MeshRenderer>().material = materials[count];

                armAnim.gameObject.SetActive(false);
                //canalAnim.gameObject.SetActive(false);

                //waitToPlay2ndClip = true;



            }
            else if (count == 2)
            {
                gaiaVoice2.Stop();
                gaiaVoice2.clip = clips[count];
                gaiaVoice2.Play();

                gaia2Mat.material = materials[count];

                muck.SetActive(true);

                canalAnim.transform.gameObject.SetActive(true);

                barge2.SetActive(false);
                barge3.SetActive(false);
                barge4.SetActive(false);
                barge5.SetActive(false);

                barge2.SetActive(true);
                barge3.SetActive(true);
                barge4.SetActive(true);
                barge5.SetActive(true);

                gaiaGas.SetActive(true);

                //time = 0f;

                //waitCoalDrop2 = false;
                //waitCoalDrop3 = true;

                //truck.SetActive(true);
                //gaiaAnim.enabled = true;

                //gaiaBod.GetComponent<MeshRenderer>().material = materials[count];

            }
            // Phase 4
            else if (count == 3)
            {
                gaiaVoice2.Stop();
                gaiaVoice2.clip = clips[count];
                gaiaVoice2.Play();

                gaia2Mat.material = materials[count];
                //gaia2.SetActive(false);
                //jointPivot2.SetActive(false);
                //gaia2_v2.SetActive(true);

                gaiaGas.SetActive(false);

                jointPivot2.GetComponent<Animator>().enabled = false;

                skyline1.SetActive(false);
                skyline2.SetActive(true);
                muck.SetActive(false);

                innerFlame.SetActive(true);

                barge2.SetActive(false);
                barge3.SetActive(false);
                barge4.SetActive(false);
                barge5.SetActive(false);

                lamp1.SetActive(true);
                lamp2.SetActive(true);

                coalHeaps.SetActive(false);

                //time = 0f;

                //waitCoalDrop3 = true;

                /*barge.SetActive(false);
                truck.SetActive(false);

                building2.SetActive(true);
                building2Smoke.SetActive(true);
                building3.SetActive(true);*/

                //gaiaBod.GetComponent<MeshRenderer>().material = materials[count];

            }
            // Phase 5
            else if (count == 4)
            {
                time = 0f;

                Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));

                //gaia2_v2.SetActive(false);
                barge.SetActive(false);
                //gaia2_v3.SetActive(true);

                //startFinalCoal = true;
                //gaia2.SetActive(true);

                gaia2Emit.GetComponent<ZibraLiquidEmitter>().enabled = false;

                jointPivot2.GetComponent<Animator>().speed = -1;
                jointPivot2.GetComponent<Animator>().Play("04_Phase2_Crane0_Intro", 0, 0f);
                jointPivot2.SetActive(false);
                gaia2.GetComponent<Animator>().speed = -1;
                gaia2.GetComponent<Animator>().Play("04_Phase2_GaiaEmerges", 0, 0f);
                gaia2.SetActive(false);

                coalDock.SetActive(false);

                phase5Intro = true;

                waitCoalDrop2 = false;

                /*gaiaVoice2.Stop();
                gaiaVoice2.clip = clips[count];
                gaiaVoice2.Play();*/

                lamp1.SetActive(false);
                lamp2.SetActive(false);
                barge.SetActive(false);

                //gaia2.SetActive(false);
                //gaia3.SetActive(true);
                //remBarge.SetActive(true);

                //gaia2Mat.material = materials[count];

                //muck.SetActive(true);

                //gaiaBod.GetComponent<MeshRenderer>().material = materials[count];

            }
            else if (count == 5)
            {
                /*powerhouseBuilding.SetActive(false);
                building2.SetActive(false);
                building2Smoke.SetActive(false);
                building3.SetActive(false);*/

                skyline2.SetActive(false);
                industrialSkyline3.SetActive(true);

                gaia3Mat.material = materials[count];

                gaiaVoice3.Stop();
                gaiaVoice3.clip = clips[count];
                gaiaVoice3.Play();

                checkGaiaAudio3 = true;

                //lamp1.SetActive(false);
                //lamp2.SetActive(false);



                //gaiaBod.GetComponent<MeshRenderer>().material = materials[count];

            }
            else if (count == 6)
            {
                gaia3Mat.material = materials[count];

                gaiaVoice3.Stop();
                gaiaVoice3.clip = clips[count];
                gaiaVoice3.Play();
            }
            else
            {
                button.SetActive(false);
            }

        }
    }
}