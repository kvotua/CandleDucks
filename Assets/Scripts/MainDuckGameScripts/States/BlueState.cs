using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueState : INPCBehavior
{
    public void Enter()
    {
        Debug.Log("BlueStart");
    }

    public void Exit()
    {
        Debug.Log("BlueEnd");
    }

    public void Update()
    {

    }
}
