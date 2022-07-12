using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleTon<AudioManager>
{
    public AudioPlayer audioObject;

    public void Play(AudioClip clip,MixerChannel channel)
    {
        var audio = Instantiate(audioObject,transform);
        audio.clip = clip;
        audio.channel = channel;
        audio.Play();
    }
}
