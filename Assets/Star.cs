using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject deathParticle;
    public AudioClip clip;
    public void Die()
    {
        Destroy(gameObject);
        Instantiate(deathParticle, transform.position,Quaternion.identity);
        AudioManager.Instance.Play(clip, MixerChannel.Effect);
    }
    
}
