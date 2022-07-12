using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinObstacle : PipeObstacle
{
    public float waittime;
    IEnumerator rotater()
    {

        WaitForSeconds wait = new WaitForSeconds(waittime);

        while(true)
        {
            transform.DORotate(transform.eulerAngles + new Vector3(0, 0, 45), 0.1f);
            yield return wait;
            //GameManager.Instance.player.GetComponent<Renderer>().enabled = false;
        }

    }
    public void Rotate()
    {

        StartCoroutine(rotater());
    }
    private void Start()
    {
        Debug.LogError("dfafsdfadf왜시작안해");
    }
}
