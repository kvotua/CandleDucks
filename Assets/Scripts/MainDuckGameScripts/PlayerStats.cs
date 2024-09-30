using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int karmaPoints;
    public int mindPoints;

    [SerializeField] private TMP_Text statsText;//временно здесь, потом в другой класс, отвечающий за ui

    public float interactRadius;

    private void Start()
    {
       // GetComponent<CircleCollider2D>().radius = interactRadius;
        ChangeStatsText();
    }

    private void ChangeStatsText()//временно здесь, потом в другой класс, отвечающий за ui
    {
        statsText.text = "карма " + karmaPoints + "\n здравомыслие " + mindPoints;
    }
}
