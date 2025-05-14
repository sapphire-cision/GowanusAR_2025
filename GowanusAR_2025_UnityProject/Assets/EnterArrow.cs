using UnityEngine;

public class EnterArrow : MonoBehaviour
{

    public GameObject arrows;
    public GameObject startToken;

    public GameObject onboardingFigure;
    public GameObject tidemill;

    public GameObject onboardingTimeline;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onboardingTimeline.SetActive(false);
        arrows.SetActive(false);
        startToken.SetActive(true);
        onboardingFigure.SetActive(false);
        tidemill.SetActive(false);

        Debug.Log("Enter Arrow Triggered");

   }
}
