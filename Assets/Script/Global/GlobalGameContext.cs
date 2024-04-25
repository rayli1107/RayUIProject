using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalGameConfig
{
    public static Action statUpdateAction;

    private static float _audioVolume;
    public static float audioVolume
    {
        get => _audioVolume;
        set
        {
            _audioVolume = value;
            statUpdateAction?.Invoke();
        }
    }

    private static bool _isInitialized = false;
    public static bool isInitialized => _isInitialized;

    public static void Initialize()
    {
        audioVolume = 0.2f;
        _isInitialized = true;
    }
}

public static class GlobalSceneManager
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}