using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenuUI;
    void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop the game time
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");

        // Hide the game over menu
    }
}
