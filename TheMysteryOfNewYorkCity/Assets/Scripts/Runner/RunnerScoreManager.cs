using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RunnerScoreManager : MonoBehaviour
{

    
    public int score;
    public TextMeshProUGUI  scoreDisplay;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")){
            score++;
            scoreDisplay.text = (score/2).ToString();
            Debug.Log(score);
            if (score==20){
                SceneManager.LoadScene("Credits");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
