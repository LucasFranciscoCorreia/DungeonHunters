using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{

    public float volume;

    public void Awake()
    {
        volume = 1;
        DontDestroyOnLoad(this.gameObject);
    }


    public void SetVolume(float vol)
    {
        this.volume = vol;
    }

}
