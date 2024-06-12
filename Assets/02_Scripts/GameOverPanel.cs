
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // ������ �Ͻ� ����
    }

    public void ReturnToMenu()
    {
        // �޴� ��
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // ���� �Ͻ� ���� ����
    }

    public void RestartGame()
    {
        // ���� ���� �ٽ� �ε��Ͽ� ������ �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; // ���� �Ͻ� ���� ����
    }
}
