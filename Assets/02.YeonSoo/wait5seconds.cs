using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wait5seconds : HitObstacle
{
    
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
