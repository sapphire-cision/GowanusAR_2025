using UnityEngine;

public class TurnOffAfter5Seconds : MonoBehaviour
{
    private float time = 0f;

    private bool playVoice = false;

    public AudioSource gowanusAudio;

    void Update()
    {
        time += Time.deltaTime;

        if(time>=3f && playVoice == false)
        {
            playVoice = true;

            gowanusAudio.Play();
        }

        if (time >= 10f)
        {

            this.gameObject.SetActive(false);
        }
    }
}
