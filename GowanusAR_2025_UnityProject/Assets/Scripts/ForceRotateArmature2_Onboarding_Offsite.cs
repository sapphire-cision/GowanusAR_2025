using UnityEngine;

public class ForceRotateArmature2_Onboarding_Offsite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.localRotation != Quaternion.Euler(0, 90, 0))
        {
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
            // Force the rotation to be zero
            //ForceRotation();
        }
    }
}
