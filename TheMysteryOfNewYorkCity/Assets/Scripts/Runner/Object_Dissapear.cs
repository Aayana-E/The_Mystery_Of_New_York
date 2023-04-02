using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Dissapear : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(true);
        Destroy(uiObject, 5f);
        //StartCoroutine("WaitForSec");
        //StartCoroutine("Delete");


    }

 
    IEnumerator WaitForSec()
    {
        //Destroy(gameObject);
        //Destroy(uiObject);

        yield return new WaitForSeconds(5);

    }
    IEnumerator Delete()
    {
       Destroy(uiObject);
        yield return new WaitForSeconds(5);

    }
}
