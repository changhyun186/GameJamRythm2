using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InGameBlackPanel : MonoBehaviour
{
    public float amount=100;
    private void Start()
    {
        transform.DOMoveX(amount, 1);
    }
}
