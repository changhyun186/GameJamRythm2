using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraEffect : MonoSingleTon<CameraEffect>
{
    public float minX, maxX, minY, maxY;

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
        print(pos);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.DOMove(pos, toCircleDuration);
    }

    public void toTarget()
    {
        Vector3 pos = GameManager.Instance.curHitObstacle.transform.position;
        pos.z -= 10;
        print(pos);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.DOMove(pos, toCircleDuration);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector2(minX,minY),new Vector2(maxX,minY));
        Gizmos.DrawLine(new Vector2(maxX,minY),new Vector2(maxX,maxY));
        Gizmos.DrawLine(new Vector2(maxX,maxY),new Vector2(minX,maxY));
        Gizmos.DrawLine(new Vector2(minX,maxY),new Vector2(minX,minY));
        
    }
}