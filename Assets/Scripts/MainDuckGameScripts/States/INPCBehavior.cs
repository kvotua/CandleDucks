using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCBehavior 
{
    void Enter(SpriteRenderer spriteRenderer, int colorPercent, bool isOneState);
    void Exit();
    void Update(float distance, float maxRadius, float minRadius);
}
