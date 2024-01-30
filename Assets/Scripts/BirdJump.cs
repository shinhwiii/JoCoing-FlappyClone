using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdJump : MonoBehaviour
{
    private Rigidbody2D rigid;
    private AudioSource audioSource;
    private bool isLive;
    private float startTime;

    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private AudioClip[] clips;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isLive = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isLive)
        {
            audioSource.clip = clips[0];
            audioSource.Play();

            rigid.velocity = Vector2.up * jumpPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreUp"))
        {
            Score.score++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (Score.score > Score.bestScore)
            {
                Score.bestScore = Score.score;
                PlayerPrefs.SetInt("BestScore", Score.bestScore);
            }

            isLive = false;
            audioSource.clip = clips[1];
            audioSource.Play();

            Time.timeScale = 0f;
            startTime = Time.realtimeSinceStartup;
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.5f)
        {
            yield return null;
            elapsedTime = Time.realtimeSinceStartup - startTime;
        }

        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOverScene");
    }
}
