using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.XR.ARFoundation;

public class Item1Click : MonoBehaviour, IPointerClickHandler
{

    //public GameObject phase1;

    //public GameObject arm1;
    //public GameObject arm2;
    public GameObject timeline1;
    //public GameObject timeline2;

    //public IndustryManager indusManager;

    public TimelineManager tManager;

    public PlayableDirector onboardingTimeline;

    public GameObject onboarding;

    public GameObject nextButton;

    private bool waitForTimeline = false;

    //public AROcclusionManager occlusionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForTimeline && onboardingTimeline.state == PlayState.Paused)
        {
            waitForTimeline = false;
            onboardingTimeline.Play();
            //Debug.Log("Waiting for timeline to pause");
            this.gameObject.SetActive(false);
        }
    }

    /*public void OnMouseDown(){
        

        spongeManager.Retention();

    }*/

    public void OnPointerClick(PointerEventData eventData)
    {

        

        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }

        if (this.gameObject.tag == "1")
        {
            this.gameObject.SetActive(false);
            timeline1.SetActive(true);
            onboarding.SetActive(false);
            timeline1.GetComponent<PlayableDirector>().Play();
            //occlusionManager.enabled = false;

        }
        else if (this.gameObject.tag == "0")
        {
            waitForTimeline = true;
            //onboardingTimeline.Play();
            Debug.Log("Clicked on 0");

        }
        else
        {

            //phase1.SetActive(false);

            /*arm1.SetActive(false);
            arm2.SetActive(true);

            timeline1.SetActive(false);
            timeline2.SetActive(true);

            indusManager.time = 0f;
            indusManager.waitCoalDrop = true;

            //indusManager.count = 1;

            indusManager.NextUp();*/
            this.gameObject.SetActive(false);
            tManager.NextMiniscene();
        }
    }
}
