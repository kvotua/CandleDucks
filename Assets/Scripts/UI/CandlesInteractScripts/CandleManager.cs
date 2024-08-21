using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleManager : MonoBehaviour
{
    private CandleInfo currentCandle;
    public static Action<CandleInfo> OnCandlesSceneLoad;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CandlesSlider.OnCandleIsSelected += SelectCandle;
    }

    public void SelectCandle(CandleInfo candle)
    {
        currentCandle = candle;
        SceneManager.LoadScene(1);
        Invoke("SendCandleIsSelectedActivator", 0.5f);
    }

    private void OnDestroy()
    {
        CandlesSlider.OnCandleIsSelected -= SelectCandle;
    }

    private void SendCandleIsSelectedActivator() => SendCandleIsSelected(currentCandle);
    public static void SendCandleIsSelected(CandleInfo candleInfo)//
    {
        OnCandlesSceneLoad.Invoke(candleInfo);
    }
}
