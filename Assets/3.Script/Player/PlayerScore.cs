using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScore : MonoBehaviour
{
    private int playerScore = 0;
    public int Playerscore => playerScore;
    [SerializeField] private Text ScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        playerScore = 0;
    }

    public void SetScore(int plusScore)
    {
        playerScore += plusScore;
        ScoreText.text = "Score: " + playerScore;
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", playerScore);
    }
}
