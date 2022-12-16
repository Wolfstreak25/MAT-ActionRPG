using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance{get {return instance;}}
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public bool isMute = false;
    public float Volume = 1f;
    public SoundType[] Sounds;
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() 
    {
        PlayMusic(global::Sounds.Music);
    }
    public void setVolume(float volume)
    {
        Volume =volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("clip not found for sound type : " + sound);
        }
    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("clip not found for sound type : " + sound);
        }
        
    }
    public void PauseMusic()
    {
        soundMusic.Pause();
    }
    public void Mute(bool Status)
    { 
         isMute = Status;
    }
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
        if(item != null)
        {
            return item.soundClip;
        }
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}
public enum Sounds
{
    PickObject,
    EnemyKill,
    Start,
    Complete,
    Music,
    Attack,
    ButtonClick
}