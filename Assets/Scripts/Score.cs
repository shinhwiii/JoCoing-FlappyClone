using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int bestScore = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
