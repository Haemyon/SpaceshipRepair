using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    //�� Sound�� �迭�� �����Ѱ���?
    //Sound �ȿ����� ������� ȿ������ �ְ�, ������� �������� ���� �ְ�, ȿ������ �������� �� ������ �迭�� �����ϴ°� ���ϴ�.
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BGM");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        //sound[]�� ����� �߿��� ���� ���ϴ� ������ ã������

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
            //ȿ������ �ѹ����� ����Ǿ� �ϹǷ� PlayOneShot�� �̿��Ѵ�.
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void Play_BTN_Open()
    {
        PlaySFX("UI_Open");
    }

    public void Play_BTN_Close()
    {
        PlaySFX("UI_Close");
    }
}
