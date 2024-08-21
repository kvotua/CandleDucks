using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UIMenuHider : MonoBehaviour
{
    public GameObject oldMenu;

    public void OpenNewMenu(GameObject newMenu)
    {
        oldMenu.SetActive(false);
        oldMenu = newMenu;
        oldMenu.SetActive(true);
    }

    public void BlurEffectChange()
    {
        PostProcessVolume postProcessVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        postProcessVolume.enabled = !postProcessVolume.enabled;
    }
}
