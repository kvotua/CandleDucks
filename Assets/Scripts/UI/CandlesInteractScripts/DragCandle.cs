using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCandle : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Vector3 offset;
    [SerializeField] private Image candleImage;
    private CandleInfo candleInfo;
    public static Action<CandleInfo> OnCandleIsActivate;

    private void Awake()
    {
        CandleManager.OnCandlesSceneLoad += SetupCandle;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = gameObject.transform.position - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = newPosition + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flame")
        {
            SendOnCandleIsActivate(candleInfo);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        CandleManager.OnCandlesSceneLoad -= SetupCandle;
    }

    private void SetupCandle(CandleInfo candle)
    {
        candleInfo = candle;
        candleImage.sprite = candleInfo.candleSprite;
    }

    public static void SendOnCandleIsActivate(CandleInfo candleInfo)//
    {
        OnCandleIsActivate.Invoke(candleInfo);
    }
}
