using UnityEngine;

public class TurnOffAfter10Seconds : MonoBehaviour
{
    private float time = 0f;



    void Update()
    {
        time += Time.deltaTime;

        if (time >= 20f)
        {

            this.gameObject.SetActive(false);
        }
    }
}
