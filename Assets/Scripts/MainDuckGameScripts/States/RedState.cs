using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedState : INPCBehavior
{
    public void Enter()
    {
        Debug.Log("RedStart");
    }

    public void Exit()
    {
        Debug.Log("RedEnd");
    }

    public void Update()
    {
    }
}
