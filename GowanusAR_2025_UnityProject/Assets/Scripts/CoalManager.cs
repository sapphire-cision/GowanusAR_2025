using UnityEngine;

public class CoalManager : MonoBehaviour
{

    public GameObject coal;
    public GameObject coalPrefab;

    public GameObject finalCoal;

    public void MakeCoal2(){
        Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
        //finalCoal.SetActive(false);
        Instantiate(coalPrefab, coal.transform.position, coal.transform.rotation);
    }

    /*public void MakeCoal1(){
        Instantiate(coalPrefab, finalCoal.transform.position, finalCoal.transform.rotation);
    }

    public void MakeCoal2(){
        Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
        Instantiate(coalPrefab, finalCoal.transform.position, finalCoal.transform.rotation);
    }*/

    public void MakeCoal3(){
        //Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));
        //Instantiate(coalPrefab, coal.transform.position, coal.transform.rotation);

        //finalCoal.SetActive(true);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
