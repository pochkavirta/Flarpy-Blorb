using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource dingSFX;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (bird.birdIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = "Score: " + playerScore.ToString();
            dingSFX.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        bird.birdIsAlive = false;
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = "High Score: " + playerScore.ToString();
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
