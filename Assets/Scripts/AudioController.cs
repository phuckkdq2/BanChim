using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    
    [Header("Main Setting")]
    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float sfxVolume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [Header("Game Sounds And Music:")]
    public AudioClip shooting;
    public AudioClip Win ;
    public AudioClip lose ;
    public AudioClip[] bgMusic;

    public override void Start() {
        PlayMusic(bgMusic);
    }

    public void PlaySound(AudioClip sound , AudioSource aus = null){

        if(!aus){
            aus = sfxAus;
        }

        if(aus){
            aus.PlayOneShot(sound, sfxVolume);
        }
    }

    public void PlaySound(AudioClip[] sounds, AudioSource aus = null){

        if(!aus){
            aus = sfxAus;
        }

        if(aus){
            int randIdx = Random.Range(0 , sounds.Length);

            if(sounds[randIdx] != null){
                aus.PlayOneShot( sounds[randIdx], sfxVolume);
            }
        }
    }

    public void PlayMusic (AudioClip music , bool loop = true){

        if(musicAus){

            musicAus.clip = music;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }      
    }

    public void PlayMusic(AudioClip[] music , bool loop = true){

        if(musicAus){
            int randIdx = Random.Range(0 , music.Length);

            if(music[randIdx] != null){
                musicAus.clip = music[randIdx];
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }

    }  
}
