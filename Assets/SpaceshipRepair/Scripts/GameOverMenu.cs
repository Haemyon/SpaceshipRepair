using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public Text currentScoreText;
    public Text highScoreText;
    private int currentScore;
    private int highScore;

    void Start()
    {
        // 게임 오버 UI를 비활성화합니다.
        gameOverMenuUI.SetActive(false);

        // 최고 점수를 불러옵니다.
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 기본값을 0으로 설정
    }

    public void ShowGameOverMenu(int score)
    {
        gameOverMenuUI.SetActive(true);

        // 현재 점수를 UI에 반영합니다.
        currentScore = score;
        currentScoreText.text = currentScore.ToString();

        // 최고 점수 갱신 여부 확인 및 저장
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // 즉시 저장
            highScoreText.text = highScore.ToString() + " (NEW)";
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}