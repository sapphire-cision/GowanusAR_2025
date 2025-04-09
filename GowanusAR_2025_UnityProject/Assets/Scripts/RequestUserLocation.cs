using UnityEngine;
using UnityEngine.iOS;

public class RequestUserLocation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogWarning("Location services not enabled by user.");
            return;
        }

        Input.location.Start();
        Input.compass.enabled = true;

        Debug.Log("Location started.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
