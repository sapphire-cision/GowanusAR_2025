using UnityEngine;

public class ChemicalManager : MonoBehaviour
{

    public GameObject chem;
    public GameObject chemPrefab;


    public void MakeChem2(){
        Destroy(GameObject.Find("C_Model_Pack_MK3D (5)(Clone)"));

        Instantiate(chemPrefab, chem.transform.position, chem.transform.rotation);
    }

}
