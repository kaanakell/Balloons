using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameOverScript GameOverScreen;

    public TextMeshProUGUI scoreText;
    private int score;

    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}
