using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    public GameObject timeoutPanel;
    public GameObject pauseButton;
    float currCountdownValue;
    public bool isGameActive;
    private int score;


    public void Start()
    {
        // timeoutPanel = GameObject.Find("Timeout Panel");
    }
    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0 && isGameActive)
        {
            timeLeftText.text = "Time: " + currCountdownValue.ToString("0");
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {

        isGameActive = true;
        score = 0;
        UpdateScore(0);
        scoreText.gameObject.SetActive(true);
        timeLeftText.gameObject.SetActive(true);
        StartCoroutine("StartCountdown", 60);

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
    public void GameOver()
    {
        timeoutPanel.SetActive(true);
        isGameActive = false;
        finalScoreText.text = "Final Score: " + score.ToString();
        pauseButton.SetActive(false);
        Time.timeScale = 0f; // Pausa el juego
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
