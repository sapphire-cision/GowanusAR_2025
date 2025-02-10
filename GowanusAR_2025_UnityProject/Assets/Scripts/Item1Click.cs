using UnityEngine;

using UnityEngine.EventSystems;

public class Item1Click : MonoBehaviour, IPointerClickHandler
{

    public GameObject phase1;

    public GameObject arm1;
    public GameObject arm2;
    public GameObject timeline1;
    public GameObject timeline2;

    public IndustryManager indusManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void OnMouseDown(){
        

        spongeManager.Retention();

    }*/

    public void OnPointerClick(PointerEventData eventData)
    {

        this.gameObject.SetActive(false);

        //phase1.SetActive(false);

        arm1.SetActive(false);
        arm2.SetActive(true);

        timeline1.SetActive(false);
        timeline2.SetActive(true);

        indusManager.time = 0f;
        indusManager.waitCoalDrop = true;

        //indusManager.count = 1;

        indusManager.NextUp();


    }
}
