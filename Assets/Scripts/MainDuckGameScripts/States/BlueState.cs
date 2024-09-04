using UnityEngine;

public class BlueState : INPCBehavior
{
    private int curPercentBlueColor;
    public void Enter(SpriteRenderer spriteRenderer, int colorPercent)
    {
        curPercentBlueColor = colorPercent*3;

        spriteRenderer.color -= new Color(0, 255,255- curPercentBlueColor, 0);
        Debug.Log("BlueStart");
    }

    public void Exit(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color += new Color(0, 255, 255-curPercentBlueColor, 0);
        curPercentBlueColor = 0;

        Debug.Log("BlueEnd");
    }

    public void Update()
    {

    }
}
