using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{

    public float volume;
    private AudioManager audio;

    public void Awake()
    {
        volume = 1;
        DontDestroyOnLoad(this.gameObject);
        audio = GameObject.FindObjectOfType<AudioManager>();
    }


    public void SetVolume(float vol)
    {
        this.volume = vol;
        audio.SetVolume(vol);
    }

}
