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
            if (!player.isKeyDownAble)
            {
                player.Die();
                return;
            }
            curHitObstacle.OnLeftKeyDown();
            player.StopCor();
            curHitObstacle.Break();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (!player.isKeyDownAble)
            {
                player.Die();
                return;
            }
            curHitObstacle.OnRightKeyDown();
            player.StopCor();
            curHitObstacle.Break();
        }
    }
}
