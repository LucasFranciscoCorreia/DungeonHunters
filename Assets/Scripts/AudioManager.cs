using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        foreach(Sound sound in sounds)
        {
            Debug.Log(sound.name + " == " + name + "?");
            Debug.Log(sound.name.Equals(name));
            if (sound.name.Equals(name))
            {
                sound.source.Play();
                break;
            }
        }
        Debug.Log("#############################");
    }
}
