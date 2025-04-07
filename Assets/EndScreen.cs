using System;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private string uglyText = "Reached a depth of {0} deep!";
    
    private void Start()
    {
        int score = ScoreTracker.Instance != null ? ScoreTracker.Instance.CurrentScore : 0;
        text.SetText(String.Format(uglyText, score));
    }
}
