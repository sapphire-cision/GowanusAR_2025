using UnityEngine;

public class ForceRotateArmature_Canal_Onsite : MonoBehaviour
{

    private float time = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (this.gameObject.transform.localRotation != Quaternion.Euler(0, -30, 0))
        {
            this.gameObject.transform.localRotation = Quaternion.Euler(0, -30, 0);
            // Force the rotation to be zero
            //ForceRotation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 5f)
        {
            if (this.gameObject.transform.localRotation != Quaternion.Euler(0, -30, 0))
            {
                this.gameObject.transform.localRotation = Quaternion.Euler(0, -30, 0);
                // Force the rotation to be zero
                //ForceRotation();
            }
            time = 0f; // Reset the timer
            this.enabled = false; // Disable this script after the first 5 seconds
        }

        
        /*if (this.gameObject.transform.localRotation != Quaternion.Euler(0, -30, 0))
        {
            this.gameObject.transform.localRotation = Quaternion.Euler(0, -30, 0);
            // Force the rotation to be zero
            //ForceRotation();
        }*/

    }
}
