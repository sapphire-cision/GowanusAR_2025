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
        this.gameObject.transform.localRotation = Quaternion.Euler(-5.186f, 34.874f, -2.108f);
    }
}
