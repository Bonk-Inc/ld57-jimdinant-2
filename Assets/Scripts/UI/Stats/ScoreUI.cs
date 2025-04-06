using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
