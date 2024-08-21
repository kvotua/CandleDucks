using UnityEngine;
[System.Serializable]
public class CandleInfo
{
    public string candleName;
    public Sprite candleSprite;
    [HideInInspector]public bool isBurn;
    public float burnTime;
    public float currentBurnTime;//тоже спрятать когда доделается загрузка из бд
}
