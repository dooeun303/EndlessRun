using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true); // pauseMenu 게임 오브젝트를 true로
        Time.timeScale = 0; // 정지하면 시간을 0으로
    }

    public void Home()
    {
        SceneManager.LoadScene(0); // 0번 씬 (메인메뉴)으로 이동
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); // pauseMenu 게임 오브젝트를 false로
        Time.timeScale = 1; // 재개하면 다시 시작
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
