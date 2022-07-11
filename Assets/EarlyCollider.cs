using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyCollider : MonoBehaviour
{
    public HitObstacle myObstacle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            print("fadfafdasfasfsdfasf");
            GameManager.Instance.player.isEalryHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.player.isEalryHit = false;
        }
    }
}
