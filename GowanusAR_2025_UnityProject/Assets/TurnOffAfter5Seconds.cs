using UnityEngine;

public class TurnOffAfter5Seconds : MonoBehaviour
{
    private float time = 0f;

    
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5f)
        {

            this.gameObject.SetActive(false);
        }
    }
}
