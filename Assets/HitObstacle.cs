using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitObstacle : MonoBehaviour
{
    public bool isCurTarget = false;
    public HitObstacle nextObstacle;
    public Rigidbody rb;
    public Collider col;
    public bool isAlreadyHit;

    public GameObject braekPrefab;
    public ParticleSystem breakParticle;

    public string Type;

    protected virtual void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        SetIsCurTarget(false);
    }

    public virtual void SetIsCurTarget(bool isCur)
    {
        isCurTarget = isCur;
        col.enabled = isCur;
        if(isCur)
        GameManager.Instance.curHitObstacle = this;
    }

    public virtual void Break()
    {
        SetIsCurTarget(false);
        nextObstacle.SetIsCurTarget(true);
        if(breakParticle != null)
        Instantiate(breakParticle, transform.position, Quaternion.identity);
    }
    public void AlreadyKeyInput()
    {

    }

    public abstract void OnLeftKeyDown();
    public abstract void OnRightKeyDown();
}
