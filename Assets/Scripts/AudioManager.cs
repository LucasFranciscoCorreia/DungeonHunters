using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public VolumeScript volume;
    void Awake()
    {
        volume = GameObject.FindObjectOfType<VolumeScript>();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = volume.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("theme");

    }

    public void Play(string name)
    {
        foreach(Sound sound in sounds)
        {
            if (sound.name.Equals(name))
            {
                sound.source.volume = volume.volume;
                sound.source.Play();
                break;
            }
        }
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }
}
