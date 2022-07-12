using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum MixerChannel
{
    Master,Tile,Music,Effect
}

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    public AudioClip clip;
    public MixerChannel channel;
    public AudioMixer mixer;

    [ContextMenu("Play")]
    public void Play()
    {
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups(channel.ToString())[0];
        audioSource.Stop();
        if(clip != null)
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(gameObject, 10);
    }

}
