using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public bool isLive = false;
    private float startTime;

    private void Awake()
    {
        manager = this;
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void GameStart()
    {
        isLive = true;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameOver()
    {
        isLive = false;

        Time.timeScale = 0f;
        startTime = Time.realtimeSinceStartup;
        StartCoroutine(OnGameOver());
    }

    private IEnumerator OnGameOver()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.3f)
        {
            yield return null;
            elapsedTime = Time.realtimeSinceStartup - startTime;
        }

        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOverScene");
    }
}
