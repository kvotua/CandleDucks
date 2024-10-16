using UnityEngine;

public class BlueState : INPCBehavior
{
    private bool _isOneState;
    private SpriteRenderer npcSprite;
    private float maxColorPercent;
    private float distanceDifference;
    private Color curColor;
    public void Enter(SpriteRenderer spriteRenderer, int colorPercent, bool isOneState)
    {
        _isOneState = isOneState;
        npcSprite = spriteRenderer;
        if (isOneState)
        {
            maxColorPercent = (float)colorPercent / 100;
            npcSprite.color = new Color(0, 0, 1, 1);
            curColor = new Color(0, 0, 1, 1);
        }
        else
            maxColorPercent = (float)colorPercent / 100;

        if (/*npcSprite.color.g*/
            curColor.g != 0)
            npcSprite.color = new Color(1, 0, 1, 1);
        curColor = new Color(1, 0, 1, 1);
        Debug.Log("RedStart");
    }

    public void Exit()
    {
        npcSprite.color = new Color(1, 1, 1, 1);
        curColor = new Color(1, 1, 1, 1);
        distanceDifference = 0;
        Debug.Log("RedEnd");
    }

    public void Update(float curdistance)
    {
        var distance = curdistance;
        float colorDifference = (distanceDifference - distance);
        if (colorDifference < -1)
            colorDifference = -1;
        if (_isOneState)
        {
            curColor -= new Color(0, colorDifference, colorDifference, 0);
            if (curColor.g < 0)
            {

            }
                //npcSprite.color = new Color(1, 1 - maxColorPercent, 1 - maxColorPercent, 1);
            else if (npcSprite.color.g != 0)
                npcSprite.color -= new Color(colorDifference * maxColorPercent/2, colorDifference * maxColorPercent/2, 0, 0);
            else
                npcSprite.color -= new Color(colorDifference, colorDifference,0 , 0);

        }
        else
        {
            curColor -= new Color(0, colorDifference, 0, 0);
            if (curColor.g < 0)
            {
               // if()
                //npcSprite.color = new Color(1, 1 - maxColorPercent, 1, 1);

            }
            else if (npcSprite.color.g != 0)
                npcSprite.color -= new Color(0, colorDifference / 2 * maxColorPercent, 0, 0);
            else
                npcSprite.color -= new Color(0, colorDifference / 2, 0, 0);
        }
        distanceDifference = distance;
        Debug.Log("Red upd" + npcSprite.color);
    }
}
