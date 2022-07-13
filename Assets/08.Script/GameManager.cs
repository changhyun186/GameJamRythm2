using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    public HitObstacle curHitObstacle;
    public PlayerCircle player;
    private void Start()
    {
        curHitObstacle.SetIsCurTarget(true);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(player.isEalryHit)
            {
                player.EalryKeyType = KeyType.D;
                return;
            }
            if (!player.isKeyDownAble)
            {
                player.Die();
                return;
            }
            OnKeyDDown();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (player.isEalryHit)
            {
                player.EalryKeyType = KeyType.K;
                return;
            }
            if (!player.isKeyDownAble)
            {
                player.Die();
                return;
            }
            OnKeyKDown();
        }
    }

    public void OnKeyKDown()
    {
        curHitObstacle.OnRightKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
    }

    public void OnKeyDDown()
    {
        curHitObstacle.OnLeftKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
    }

    public void Complete()
    {
    }
}
