using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private Rigidbody2D rigid;
    private AudioSource audioSource;
    [SerializeField]
    private GameManager manager;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && manager.isLive)
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

            audioSource.clip = clips[1];
            audioSource.Play();

            manager.GameOver();
        }
    }

}
