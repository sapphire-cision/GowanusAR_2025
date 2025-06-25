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

    //public AROcclusionManager occlusionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void OnMouseDown(){
        

        spongeManager.Retention();

    }*/

    public void OnPointerClick(PointerEventData eventData)
    {

        this.gameObject.SetActive(false);

        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }

        if (this.gameObject.tag == "1")
        {

            timeline1.SetActive(true);
            onboarding.SetActive(false);
            timeline1.GetComponent<PlayableDirector>().Play();
            //occlusionManager.enabled = false;

        }
        else if (this.gameObject.tag == "0")
        {

            onboardingTimeline.Play();

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

            tManager.NextMiniscene();
        }
    }
}
