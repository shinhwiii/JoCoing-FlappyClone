using TMPro;
using UnityEngine;

public class CurrentScore : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Score : " + Score.score.ToString();
    }
}
