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
            GetComponentInChildren<Renderer>().material.color = Color.white;
            if(nextObstacle!=null)
            nextObstacle.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1, 0.3f);

        }
        else
        {
            GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1, 0f);
        }

    }

    public virtual void Break()
    {
        AudioManager.Instance.Play(tileAudio.clip,MixerChannel.Tile);
        SetIsCurTarget(false);
        nextObstacle.SetIsCurTarget(true);
        if(breakParticle != null)
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
