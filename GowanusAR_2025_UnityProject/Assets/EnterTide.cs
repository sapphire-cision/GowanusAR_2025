using UnityEngine;

public class EnterTide : MonoBehaviour
{
    public GameObject startButton;

    private void OnTriggerEnter(Collider other)
    {
        startButton.SetActive(true);
        Debug.Log("Enter Tide Triggered");
        this.gameObject.SetActive(false);
    }
}
