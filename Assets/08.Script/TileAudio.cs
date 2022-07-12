using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAudio : MonoBehaviour
{
    public AudioClip[] clip;
    public void Play()
    {
        foreach(var clipItem in clip)
        {
            AudioManager.Instance.Play(clipItem, MixerChannel.Tile);
        }
    }
}
