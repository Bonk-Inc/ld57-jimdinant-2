using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    private GameObject player;
 
    private int startingDepth = 0;
    private int currentScore = 0;
    private int extraDepthScore = 0;
    
    private bool reachedGameOver = false;
    public int CurrentScore => currentScore;
    
    public UnityEvent<int> ScoreChanged;
    
    private static ScoreTracker instance;
    public static ScoreTracker Instance
    {
        get { return instance; }
    }

    public void AddDepthScore()
    {
        extraDepthScore += currentScore;
    }
    
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(instance.gameObject);
        }
        
        instance = this;
        DontDestroyOnLoad(this);
    
        player = (FindFirstObjectByType(typeof(WormMovement)) as WormMovement).gameObject;
        startingDepth = Mathf.CeilToInt(player.transform.position.y);
        
        ScoreChanged.Invoke(currentScore);
    }

    private void Update()
    {
        if (player != null) UpdateScore();
        
        reachedGameOver = true;
    }

    private void UpdateScore()
    {
        if (reachedGameOver)
        {
            currentScore = 0;
            reachedGameOver = false;
        }
        
        var newScore = -Mathf.CeilToInt(player.transform.position.y - startingDepth) + extraDepthScore;

        if (newScore > currentScore)
        {
            currentScore = newScore;
            ScoreChanged.Invoke(currentScore);
        }
    }
}
