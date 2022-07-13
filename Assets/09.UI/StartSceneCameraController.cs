using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartSceneCameraController : MonoBehaviour
{
    public Transform target;
    public void ToTarget()
    {
        transform.DOMoveX(target.position.x, 1);
    }
    private void Update()
    {
        ToTarget();
    }
}
