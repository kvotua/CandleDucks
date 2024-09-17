using UnityEngine;

public class RedState : INPCBehavior
{
    private bool _isOneState;
    private SpriteRenderer npcSprite;
    private float maxColorPercent;
    private float distanceDifference;
    public void Enter(SpriteRenderer spriteRenderer, int colorPercent, bool isOneState)
    {
        _isOneState = isOneState;
        npcSprite = spriteRenderer;
        if (isOneState)
        {
            maxColorPercent = (float)colorPercent / 256 * 2.56f;
            npcSprite.color = new Color(1, 0, 0, 1);
        }
        else
            maxColorPercent = ((float)colorPercent / 256 * 2.56f) / 2;

        if (npcSprite.color.g != 0)
            npcSprite.color = new Color(1, 0, 1, 1);
        Debug.Log("RedStart");
    }

    public void Exit()
    {
        npcSprite.color = new Color(1, 1, 1, 1);
        distanceDifference = 0;
        Debug.Log("RedEnd");
    }

    public void Update(float distance)
    {
        float colorDifference = (float)maxColorPercent * (distanceDifference - distance);
        if (_isOneState)
            npcSprite.color -= new Color(0, colorDifference, colorDifference, 0);
        else
            npcSprite.color -= new Color(0, colorDifference, 0, 0);
        distanceDifference = distance;
    }
}
