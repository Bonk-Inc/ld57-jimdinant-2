using Bonk.BonkIncBackend.Entities;
using Bonk.BonkIncBackend.UI;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    
    [SerializeField]
    private SubmitScore submitScore;

    private void Awake()
    {
        submitScore.OnScoreSaved += HandleScoreSaved;
    }
    
    private void Start()
    {
        var score = ScoreTracker.Instance.CurrentScore;
        submitScore.SubmitAchievedScore(score, currentScore => currentScore.score < score);
    }

    private void HandleScoreSaved(Score _)
    {
        
    }
}
