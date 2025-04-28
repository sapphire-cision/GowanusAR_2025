using UnityEngine;
using UnityEngine.Playables;

public class TransitionItemManager : MonoBehaviour
{

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;

    private Vector3 startPos;

    public Transform endMarker;

    private Quaternion startRotation;
    private Quaternion endRotation;

    // Movement speed in units per second.
    private float speed = 5.0f;

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

    public GameObject[] transitionItems;

    public GameObject[] transitionPrefabs;

    private int itemCount = 0;

    public Animator trackedExcavator;

    public PlayableDirector timeline2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            //transitionItems[itemCount].transform.localScale = Vector3.Lerp(startScale, targetScale, fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            transitionItems[itemCount].transform.position = Vector3.Lerp(startPos, endMarker.position, fractionOfJourney);
            Debug.Log(transitionItems[itemCount].transform.position);

        }

    }

    public void TransitionItem(int inputItemCount){

        itemCount = inputItemCount;

        startPos = startMarker.position;

        /*
        
        transitionItems[itemCount].transform.parent = itemParentScale;
        

        */
        
        //trackedExcavator.enabled = false;
        //timeline2.Pause();

        //GameObject clone = Instantiate(transitionPrefabs[itemCount]);
        //clone.transform.position = transitionItems[itemCount].transform.position;
        

        //clone.transform.SetParent(null, true);
        //transitionItems[itemCount].SetActive(false);
        //transitionItems[itemCount] = clone;

        transitionItems[itemCount].transform.SetParent(itemParentScale, true);
        

        //trackedExcavator.enabled = true;
        //timeline2.Resume();

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPos, endMarker.position);

        startTime = Time.time;

        transitionItems[itemCount].SetActive(true);

        //transitionItems[itemCount].transform.parent = itemParentScale;

        transit1 = true;

        startRotation = startMarker.rotation;

        //startScale = itemParentScale.localScale;
        startScale = transitionItems[itemCount].transform.localScale;
        

        //startRotation = transform.rotation;
        Vector3 endEulerAngles = startRotation.eulerAngles + Vector3.up * (360f * rotationMultiplier);
        //endMarker.rotation = Quaternion.Euler(endEulerAngles);


        //endRotation = endMarker.rotation;
        endRotation = Quaternion.Euler(endEulerAngles);

        ogRot = startRotation;


        Debug.Log(startRotation);
        Debug.Log(endRotation);

        //itemCount++;


    }

}
