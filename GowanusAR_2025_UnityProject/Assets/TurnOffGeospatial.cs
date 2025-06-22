using UnityEngine;
using Google.XR.ARCoreExtensions.GeospatialCreator;

public class TurnOffGeospatial : MonoBehaviour
{

    public ARGeospatialCreatorAnchor[] anchors;
    public GameObject xrOrigin;
    public GameObject offlinestartAnchor;

    public GameObject tideTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOffAnchors()
    {
        xrOrigin.transform.position = offlinestartAnchor.transform.position;
        xrOrigin.transform.rotation = offlinestartAnchor.transform.rotation;
        tideTrigger.SetActive(false);

        for (int i = 0; i < anchors.Length; i++)
        {
            if (anchors[i] != null)
            {
                anchors[i].enabled = false;
            }
        }
    }
}
