using UnityEngine;

public class RedState : INPCBehavior
{
    private int curPercentRedColor;
    public void Enter(SpriteRenderer spriteRenderer, int colorPercent)
    {

        curPercentRedColor  = colorPercent* 3;

        spriteRenderer.color -= new Color(255-curPercentRedColor, 255, 0,0);
        Debug.Log("RedStart");
    }

    public void Exit(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color += new Color(255 - curPercentRedColor, 255, 0,0);
        curPercentRedColor = 0;

        Debug.Log("RedEnd");
    }

    public void Update()
    {
    }
}
