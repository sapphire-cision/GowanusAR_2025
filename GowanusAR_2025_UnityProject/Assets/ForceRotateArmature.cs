using UnityEngine;

public class ForceRotateArmature : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.localRotation != Quaternion.Euler(0, 0, 0))
        {
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            // Force the rotation to be zero
            //ForceRotation();
        }
        
    }
}
