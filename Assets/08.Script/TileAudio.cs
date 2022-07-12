using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAudio : MonoBehaviour
{
    public AudioClip clip;
    public void Play()
    {
        AudioManager.Instance.Play(clip, MixerChannel.Tile);
    }
}
