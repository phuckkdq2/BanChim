using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SingleDarwin
{
    private static AudioController instance;
     public static AudioController Instance { get => instance;}
    
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

    public static AudioController Instance0 { get => Instance1; set => Instance1 = value; }
    public static AudioController Instance1 { get => Instance2; set => Instance2 = value; }
    public static AudioController Instance2 { get => Instance3; set => Instance3 = value; }
    public static AudioController Instance3 { get => Instance4; set => Instance4 = value; }
    public static AudioController Instance4 { get => Instance5; set => Instance5 = value; }
    public static AudioController Instance5 { get => Instance6; set => Instance6 = value; }
    public static AudioController Instance6 { get => instance; set => instance = value; }

    public void Start() {
        PlayMusic(bgMusic);
    }

    public override void Awake() {
        AudioController.instance = this;
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
