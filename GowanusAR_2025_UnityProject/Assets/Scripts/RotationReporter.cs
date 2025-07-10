using UnityEngine;

public class RotationReporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{this.gameObject.name}'s Rotation: {transform.localRotation.eulerAngles.x}, {transform.localRotation.eulerAngles.y}, {transform.localRotation.eulerAngles.z}");
    }
}
