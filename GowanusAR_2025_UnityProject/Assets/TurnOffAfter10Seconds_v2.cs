using UnityEngine;

public class TurnOffAfter10Seconds_v2 : MonoBehaviour
{
    private float time = 0f;


    void Update()
    {
        time += Time.deltaTime;

        

        if (time >= 7.5f)
        {

            this.gameObject.SetActive(false);
        }
    }
}
