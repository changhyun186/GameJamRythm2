using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorObstacle : HitObstacle
{


    public override void Break()
    {
        base.Break();
        Destroy(gameObject);
    }

    public override void OnLeftKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.rotation = Quaternion.LookRotation(player.targetDir);
        player.isKeyDownAble = false;
    }

    public override void OnRightKeyDown()
    {
        var player = GameManager.Instance.player;
        player.transform.rotation = Quaternion.LookRotation(-player.targetDir);
        player.isKeyDownAble = false;
    }
}
