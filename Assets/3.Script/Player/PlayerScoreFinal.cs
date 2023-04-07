using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreFinal : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    private int playerScore;

    void Start()
    {
        GetScore();
        ScoreText.text = "Score: " + playerScore;
    }

    void GetScore()
    {
        playerScore = PlayerPrefs.GetInt("Score", playerScore);
    }
}
