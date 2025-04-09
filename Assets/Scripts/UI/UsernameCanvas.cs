using System;
using Bonk.BonkIncBackend;
using Bonk.BonkIncBackend.Entities;
using Bonk.BonkIncBackend.Settings;
using Bonk.BonkIncBackend.UI;
using Bonk.StandardLibrary.GameFlow.SceneLoading;
using UnityEngine;
using UnityEngine.UI;

public class UsernameCanvas : MonoBehaviour
{

    [SerializeField] private string gameId;
    
    [SerializeField]
    private RegisterUser register;
    
    [SerializeField]
    private Button registerButton;
    
    [SerializeField]
    private Canvas canvas;

    private BabsDao _babsDao;
    
    private void Awake()
    {
        if (string.IsNullOrEmpty(gameId))
        {
            var settings = BonkIncBackendSettings.Load();
            _babsDao = new BabsDao(settings);
        }
        else
        {
            _babsDao = new BabsDao(gameId);
        }
            
        register.OnUserRegistered += HandleUserRegistered; 
    }

    private void OnEnable()
    {
        CheckUserRegistered();
    }

    public void SubmitUsername() =>
        register.OnRegisterSubmit();

    private void HandleUserRegistered(User _)
    {
        canvas.enabled = false;
        SceneLoader.Instance.LoadScene("Play");
    }

    private void CheckUserRegistered()
    {
        if (string.IsNullOrWhiteSpace(PlayerPrefs.GetString(User.PlayerPrefField, string.Empty)))
            return;
        
        Debug.Log("OnEnable");
        HandleUserRegistered(new User());
    }
}
