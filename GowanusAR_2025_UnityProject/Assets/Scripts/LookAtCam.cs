using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        //transform.LookAt(target);

        //Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        //this.transform.LookAt(targetPosition);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        transform.LookAt(new Vector3(target.position.x, this.transform.position.y, target.position.z));
    }
}
