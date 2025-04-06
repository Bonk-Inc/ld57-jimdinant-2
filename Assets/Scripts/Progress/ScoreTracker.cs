using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    private GameObject player;
 
    private int startingDepth = 0;
    
    private int currentScore = 0;
    public int CurrentScore => currentScore;
    
    public UnityEvent<int> ScoreChanged;
    
    private void Awake()
    {
        player = (FindFirstObjectByType(typeof(WormMovement)) as WormMovement).gameObject;
        startingDepth = Mathf.CeilToInt(player.transform.position.y);
        
        ScoreChanged.Invoke(currentScore);
    }

    private void Update()
    {
        var newScore = -Mathf.CeilToInt(player.transform.position.y - startingDepth);

        if (newScore > currentScore)
        {
            currentScore = newScore;
            ScoreChanged.Invoke(currentScore);
        }
    }
}
