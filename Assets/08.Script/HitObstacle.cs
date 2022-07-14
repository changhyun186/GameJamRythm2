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

    public GameObject breakPrefab;
    public ParticleSystem breakParticle;
    public TileAudio tileAudio;

    public string Type;

    protected virtual void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        tileAudio = GetComponentInChildren<TileAudio>();
        SetIsCurTarget(false);
    }

    public virtual void SetIsCurTarget(bool isCur)
    {
        isCurTarget = isCur;
        col.enabled = isCur;
        if (isCur)
        {
            GameManager.Instance.curHitObstacle = this;
            SetAlpha(1);
            if (nextObstacle != null)
            {
                nextObstacle.SetAlpha(0.3f);

            }

        }
        else
        {
           SetAlpha(0);
        }

    }
    void SetAlpha(float i)
    {
        var mat = GetComponentInChildren<Renderer>().material;
        var color = mat.color;
        color.a = i;
        mat.color = color;
    }
    public virtual void Break()
    {
        tileAudio?.Play();
        SetIsCurTarget(false);
        nextObstacle?.SetIsCurTarget(true);
        if (breakParticle != null)
            Instantiate(breakParticle, transform.position, Quaternion.identity);
        if(breakPrefab!=null)
            Instantiate(breakPrefab, transform.position, Quaternion.identity);
    }
    public void AlreadyKeyInput()
    {

    }

    public abstract void OnLeftKeyDown();
    public abstract void OnRightKeyDown();
}
