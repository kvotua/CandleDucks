using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogThreeSetter : MonoBehaviour
{
    [SerializeField] private DialogTree testTree;
    private void Start()
    {
        TextWriter.SetNewDialogTree(testTree);
    }
}
