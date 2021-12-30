using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text textPoint;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        textPoint.text = score.ToString() + " POINTS";
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
