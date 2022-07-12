using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SquarePattern : MonoBehaviour
{
    public float rotDuration,scaleDuration;

    // Start is called before the first frame update
    void RotateA()
    {
        transform.DORotate(transform.rotation.eulerAngles+ new Vector3(0, 0, 180), rotDuration).OnComplete(() => RotateA());
    }
    void Scaler(bool isBig = false)
    {
        transform.DOScale(isBig?Vector3.one:new Vector3(1.4f, 1.4f, 1.4f), scaleDuration).OnComplete(() => { isBig =! isBig; Scaler(isBig); });
    }
    private void Start()
    {
        RotateA();
        Scaler();
    }
}
