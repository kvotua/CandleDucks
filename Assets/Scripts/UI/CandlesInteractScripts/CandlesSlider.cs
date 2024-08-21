using System;
using UnityEngine;
using UnityEngine.UI;

public class CandlesSlider : MonoBehaviour
{
    private int currentCandleNumber = 0;
    private bool isMoving;

    [SerializeField] private CandleInfo[] _candles;

    [SerializeField] private Animator candlesUIAnimator;

    [SerializeField] private Image secondCanleImage, firstCandleImage;

    [SerializeField] private Button leftMoveButton, rightMoveButton, selectCandleButton;

    public static Action<CandleInfo> OnCandleIsSelected;

    private void Start()
    {
        leftMoveButton.onClick.AddListener(() => LeftMove());
        rightMoveButton.onClick.AddListener(() => RightMove());
        selectCandleButton.onClick.AddListener(() => SelectCandle());

        firstCandleImage.sprite = _candles[currentCandleNumber].candleSprite;
    }
    private void RightMove()
    {
        if (isMoving)
            return;

        if (currentCandleNumber == _candles.Length - 1)
        {
            currentCandleNumber = 0;
            secondCanleImage.sprite = _candles[_candles.Length - 1].candleSprite;
        }

        else
        {
            currentCandleNumber++;
            secondCanleImage.sprite = _candles[currentCandleNumber - 1].candleSprite;
        }


        firstCandleImage.sprite = _candles[currentCandleNumber].candleSprite;

        isMoving = true;
        candlesUIAnimator.SetTrigger("leftMove");
        Invoke("ChangeIsMoveState", 0.5f);
        Debug.Log(currentCandleNumber);
    }

    private void LeftMove()
    {
        if (isMoving)
            return;

        if (currentCandleNumber == 0)
        {
            currentCandleNumber = _candles.Length - 1;
            secondCanleImage.sprite = _candles[0].candleSprite;
        }

        else
        {
            currentCandleNumber--;
            secondCanleImage.sprite = _candles[currentCandleNumber + 1].candleSprite;
        }

        firstCandleImage.sprite = _candles[currentCandleNumber].candleSprite;

        isMoving = true;
        candlesUIAnimator.SetTrigger("rightMove");
        Invoke("ChangeIsMoveState", 0.5f);
        Debug.Log(currentCandleNumber);
    }

    public static void SendCandleIsSelected(CandleInfo candleInfo)
    {
        OnCandleIsSelected.Invoke(candleInfo);
    }

    private void ChangeIsMoveState() => isMoving = false;
    private void SelectCandle()
    {
        SendCandleIsSelected(_candles[currentCandleNumber]);
    }
}
