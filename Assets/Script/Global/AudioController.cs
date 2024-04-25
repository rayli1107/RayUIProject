using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        GlobalGameConfig.statUpdateAction += onStatUpdate;
        onStatUpdate();
    }

    private void OnDestroy()
    {
        GlobalGameConfig.statUpdateAction -= onStatUpdate;
    }

    private void onStatUpdate()
    {
        GetComponent<AudioSource>().volume = GlobalGameConfig.audioVolume;
    }
}
