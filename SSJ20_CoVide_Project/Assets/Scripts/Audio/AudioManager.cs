using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        var sound = sounds.FirstOrDefault(x => x.name == name);
        if(sound == null)
        {
            Debug.LogWarning($"Could not found sound {name}");
            return;
        }

        sound.source.Play();
    }
}
