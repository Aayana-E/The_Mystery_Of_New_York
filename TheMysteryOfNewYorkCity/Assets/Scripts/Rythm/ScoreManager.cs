using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro TotalScoreText;

    static int comboScore;
    static int totalScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
        totalScore = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        totalScore += 1;
        Instance.hitSFX.Play();
    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();
    }
    public static int GetTotalScore()
    {
        return totalScore;
    }
    public static void ResetScore(){
        totalScore = 0;
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
        TotalScoreText.text = totalScore.ToString();
        //Debug.Log("Total score from SM: " + totalScore);

    }
    
}
