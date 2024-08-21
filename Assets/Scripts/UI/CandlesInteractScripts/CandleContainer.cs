using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandleContainer : MonoBehaviour
{
    private float timerFire;
    private int timerToText;
    [SerializeField]private TMP_Text timerText;
    [SerializeField] private Image candleImage;
    private bool isBurn;
    [SerializeField]private Animator cellAnimator;

    private void Update()
    {
        if (!isBurn)
            return;

        int timerInInt = Mathf.CeilToInt(timerFire);

        timerFire -= Time.deltaTime;

        if(timerInInt > Mathf.CeilToInt(timerFire))
        timerText.text = (timerInInt-1).ToString();

        if (timerFire < 0)
            OffCandle();

    }
    public void SetupCandle(CandleInfo candleInfo)
    {
        candleImage.sprite = candleInfo.candleSprite;
        timerFire = candleInfo.currentBurnTime;
        if (timerFire <= 0)
            OffCandle();
        else
            LightCandle();

    }
    private void LightCandle()
    {
        isBurn = true;
        cellAnimator.SetBool("isBurn", true);
    }

    private void OffCandle()
    {
        isBurn = false;
        cellAnimator.SetBool("isBurn", false);
        timerText.text = "Свеча погасла :(";
    }
}
