using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{


    public GameObject nextButton;

    //public PlayableDirector[] timelines;
    public GameObject[] timelines;

    private int timelinesCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            NextMiniscene();
        }
    }

    public void NextMiniscene()
    {

        Debug.Log("New next!");

        nextButton.SetActive(false);

        // Temp fix while using prev timeline activation technique
        // if(timelinesCount == 0) 
        //   timelinesCount = 1;

        //if(timelinesCount != -1)
        //  timelines[timelinesCount].SetActive(false);
        timelines[timelinesCount].GetComponent<PlayableDirector>().Stop();
        timelines[timelinesCount].SetActive(false);


        timelines[timelinesCount + 1].SetActive(true);

        timelinesCount++;

        Item1Click[] activeComponents = GameObject.FindObjectsByType<Item1Click>(FindObjectsSortMode.None);

        foreach (var comp in activeComponents)
        {
            if (comp.gameObject.activeInHierarchy)
            {
                Debug.Log("Active GameObject with MyComponent: " + comp.gameObject.name);
                comp.gameObject.SetActive(false);
            }
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
