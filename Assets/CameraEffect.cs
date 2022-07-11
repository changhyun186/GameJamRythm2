using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraEffect : MonoSingleTon<CameraEffect>
{
    public Camera mainCam;
    public GameObject player;
    public float toCircleDuration;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }
    [ContextMenu("ToPlayer")]
    public void cameraToCircle()
    {
        Vector3 pos = player.transform.position;
        pos.z -= 10;
        transform.DOMove(pos, toCircleDuration);
    }
}