using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    public string LeveltoLoad;
     public void Play()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
