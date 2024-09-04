using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCBehavior 
{
    void Enter(SpriteRenderer spriteRenderer, int colorPercent);
    void Exit(SpriteRenderer spriteRenderer);
    void Update();
}
