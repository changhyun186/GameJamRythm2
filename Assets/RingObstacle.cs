using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingObstacle : HitObstacle
{
    public Transform leftOut, rightOut;
    public override void OnLeftKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.position = leftOut.position;
        Vector3 dir = leftOut.rotation.eulerAngles;
        dir.x = 0;
        dir.y = 0;
        player.transform.rotation = Quaternion.Euler(dir);
        player.isKeyDownAble = false;
    }

    public override void OnRightKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.position = rightOut.position;
        Vector3 dir = leftOut.rotation.eulerAngles;
        dir.x = 0;
        dir.y = 0;
        player.transform.rotation = Quaternion.Euler(dir);
        player.isKeyDownAble = false;
    }

}
