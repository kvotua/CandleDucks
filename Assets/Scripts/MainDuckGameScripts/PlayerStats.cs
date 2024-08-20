using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int karmaPoints;
    public int mindPoints;

    public float interactRadius;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = interactRadius;
    }
}
