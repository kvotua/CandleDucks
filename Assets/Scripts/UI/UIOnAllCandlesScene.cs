using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOnAllCandlesScene : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    public static Action OnExitAllCandlesScene;

    private void Awake()
    {
        exitButton.onClick.AddListener(() => ExitOnMainScene());
    }

    private void ExitOnMainScene()
    {
        SendOnExitAllCandlesScene();
        SceneManager.LoadScene(0);
    }

    public void SendOnExitAllCandlesScene()
    {
        OnExitAllCandlesScene?.Invoke();
    }

}
