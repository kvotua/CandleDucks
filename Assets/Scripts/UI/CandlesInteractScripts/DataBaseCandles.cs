using System.Collections.Generic;
using UnityEngine;

public class DataBaseCandles : MonoBehaviour
{
    [SerializeField] private List<CandleInfo> candles;
    [SerializeField] private Transform candleContainer;
    [SerializeField] private GameObject candleCell;

    private void Awake()
    {
        UIOnAllCandlesScene.OnExitAllCandlesScene += SaveCandlesData;
        DragCandle.OnCandleIsActivate += AddFullCandle;
    }
    private void Start()
    {
        LoadAllCandlesFromDataBase();
    }

    private void OnDestroy()
    {
        UIOnAllCandlesScene.OnExitAllCandlesScene -= SaveCandlesData;
        DragCandle.OnCandleIsActivate -= AddFullCandle;
    }
    private void LoadAllCandlesFromDataBase()
    {
        //загрузка всех свечей с какой либо бд
        AddCandlesToScreen();
    }

    private void AddCandlesToScreen()
    {
        foreach (var candle in candles)
        {
            CandleContainer curCandle = Instantiate(candleCell, candleContainer).GetComponent<CandleContainer>();
            curCandle.SetupCandle(candle);
        }
    }

    public void AddFullCandle(CandleInfo candle)
    {
        CandleInfo curCandle = candle;
        curCandle.currentBurnTime = curCandle.burnTime;
        Debug.Log(curCandle.currentBurnTime);
        candles.Add(curCandle);
        CandleContainer curCandleContainer = Instantiate(candleCell, candleContainer).GetComponent<CandleContainer>();
        curCandleContainer.SetupCandle(candle);
    }

    public void SaveCandlesData()
    {
        //сохрарнить результат на сервер
    }
}
