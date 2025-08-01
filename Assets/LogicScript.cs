using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource dingSFX;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (bird.birdIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
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
    }
}
