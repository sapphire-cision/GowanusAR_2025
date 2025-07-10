using UnityEngine;

public class ScaleArmTo0 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleArmDown(){
        this.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void ScaleArmUp(){
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
