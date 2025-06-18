using UnityEngine;
using Google.XR.ARCoreExtensions.GeospatialCreator;

public class TurnOffGeospatial : MonoBehaviour
{

    public ARGeospatialCreatorAnchor[] anchors;

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
        for (int i = 0; i < anchors.Length; i++)
        {
            if (anchors[i] != null)
            {
                anchors[i].enabled = false;
            }
        }
    }
}
