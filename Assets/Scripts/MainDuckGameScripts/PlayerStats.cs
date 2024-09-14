using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int karmaPoints;
    public int mindPoints;

    [SerializeField] private TMP_Text statsText;//�������� �����, ����� � ������ �����, ���������� �� ui

    public float interactRadius;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = interactRadius;
        ChangeStatsText();
    }

    private void ChangeStatsText()//�������� �����, ����� � ������ �����, ���������� �� ui
    {
        statsText.text = "karma " + karmaPoints + "\n mind " + mindPoints;
    }

    private void Update()
    {
        ChangeStatsText();
    }
}
