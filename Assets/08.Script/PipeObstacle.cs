using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : HitObstacle
{
    public Transform leftOut, rightOut;
    public override void OnLeftKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.position = leftOut.position;
        player.transform.rotation = leftOut.rotation;
        player.isKeyDownAble = false;
    }

    public override void OnRightKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.position = rightOut.position;
        player.transform.rotation = rightOut.rotation;
        player.isKeyDownAble = false;
    }

}
