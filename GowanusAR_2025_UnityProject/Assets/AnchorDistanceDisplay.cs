using UnityEngine;
using TMPro;

public class AnchorDistanceDisplay : MonoBehaviour
{
    public Transform arCameraTransform;       // Assign the AR camera in inspector
    public Transform anchorTransform;         // Assign the anchor GameObject in inspector
    public TextMeshProUGUI distanceText;

    public GameObject distancePanel;

    public GameObject onboardingTimeline;
    public GameObject onboardingAssets;

    void Update()
    {
        if (arCameraTransform != null && anchorTransform != null)
        {
            float distance = Vector3.Distance(arCameraTransform.position, anchorTransform.position);


            if (distance < 10000)
            {
                distanceText.text = $"{distance:F2} meters";
            }
            else
            {
                distanceText.text = $"Outside of city limits; go to Gowanus, Brooklyn!";
            }
            Debug.Log($"Distance from AR Camera to Anchor: {distance:F2} meters");

            if(distancePanel.activeSelf)
        {
            if(distance < 50f){
                distancePanel.SetActive(false);
                onboardingTimeline.SetActive(true);
                onboardingAssets.SetActive(true);

                this.gameObject.SetActive(false);
            }
        }
        }

        
    }


    public void CheckDistance()
    {
        if (arCameraTransform != null && anchorTransform != null)
        {
            float distance = Vector3.Distance(arCameraTransform.position, anchorTransform.position);

            if (distance > 40f){
                distancePanel.SetActive(true);
            }else{
                onboardingTimeline.SetActive(true);
                onboardingAssets.SetActive(true);
            }
            
            //distanceText.text = $"{distance:F2} meters";

            //Debug.Log($"Distance from AR Camera to Anchor: {distance:F2} meters");
        }
    }
}
