using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjectsSpawner : MonoBehaviour
{
    [SerializeField]private GameObject candleManager;

    private void Awake()
    {
        if(!FindAnyObjectByType<CandleManager>())
        Instantiate(candleManager);
    }

}
