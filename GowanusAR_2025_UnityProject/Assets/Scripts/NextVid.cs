using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class NextVid : MonoBehaviour
{

    public VideoClip[] vids;

    public VideoPlayer vidPlayer;

    private int count = 0;

    //public GameObject button;

    //public GameObject beginButton;

    public float time = 0f;


    // Start is called before the first frame update
    void Start()
    {
        NextUp();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        /*if (count == 0 && time > 22f && !beginButton.activeSelf)
        {
            button.SetActive(true);
        }
        else if (count == 1 && time > 17f)
        {
            button.SetActive(true);

        }
        else if (count == 2 && time > 22f)
        {
            button.SetActive(true);
        }*/
    }

    public void ResetTime()
    {
        time = 0f;
    }

    public void NextUp()
    {
        if(count < 3)
        {
            time = 0f;

            //button.SetActive(false);

            count += 1;
            if (vidPlayer != null)
            {
                vidPlayer.Pause();
                if (vids[count] != null)
                {
                    vidPlayer.clip = vids[count];
                    vidPlayer.Play();
                }
                
            }

        }
        else
        {
            //button.SetActive(false);
        }
        
    }

    public void Test()
    {
        Debug.Log("yo");
    }
}
