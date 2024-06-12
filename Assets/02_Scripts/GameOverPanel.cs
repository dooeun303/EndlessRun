
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // 게임을 일시 정지
    }

    public void ReturnToMenu()
    {
        // 메뉴 씬
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // 게임 일시 정지 해제
    }

    public void RestartGame()
    {
        // 현재 씬을 다시 로드하여 게임을 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; // 게임 일시 정지 해제
    }
}
