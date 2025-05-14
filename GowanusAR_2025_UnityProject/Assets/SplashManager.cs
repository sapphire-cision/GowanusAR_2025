using Unity.VisualScripting;
using UnityEngine;

public class SplashManager : MonoBehaviour
{

    private float time = 0f;

    public GameObject startMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 4f)
        {
            startMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
