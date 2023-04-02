using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassed2 : MonoBehaviour
{
   public AudioClip levelSong;
    public int requiredScore;
    public float waitTime;

    void Start()
    {
        Debug.Log("LevelPassed script started");
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelSong;
        audioSource.Play();
    }

    void Update()
    {
        // Calculate when the song will end
        //float endTime = Time.time + levelSong.length;
        string currentSceneName = SceneManager.GetActiveScene().name;
        float endTime =  levelSong.length-Time.time;

        Debug.Log("Required Score: " + requiredScore );
        Debug.Log("End time: " + endTime );


        // Use a coroutine to wait until the song is over before checking the player's score
        if (Time.time >= endTime + waitTime)
        {
            int playerScore = ScoreManager.GetTotalScore();
            Debug.Log("Player Score: " + playerScore);
            Debug.Log("Required Score: " + requiredScore );

            if (playerScore >= requiredScore)
            {
                Debug.Log("Load LevelPassed");
                // Load the next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Reload level");
                // Reload the current scene
                //Debug.Log("Resetting score and reloading scene");
                //ScoreManager.ResetScore();
                //endTime =  levelSong.length-Time.time;
                if (currentSceneName == "Level 3- Reset"){
                    SceneManager.LoadScene("Level 3 - Music");
                }         
                //else{
                //    SceneManager.LoadScene("Level 3 - Music");

               // }       
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //endTime =  levelSong.length-Time.time;
            }
        }
    }
}
