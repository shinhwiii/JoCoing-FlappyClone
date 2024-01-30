using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Best Score : " + PlayerPrefs.GetInt("BestScore");
    }
}
