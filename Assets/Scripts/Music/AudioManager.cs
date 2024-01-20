using System;
using UnityEngine;

public class AudioManager : SingletonMonobehaviour<AudioManager>
{
    public Sound[] musicSound,sfxSound;
    public AudioSource musicSource,sfxSource;

    /// <summary>
    /// 在已有的音乐资源中寻与name匹配的音频并播放
    /// </summary>
    /// <param name="name">音乐名称</param>
    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSound,x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    /// <summary>
    /// 在已有的音效资源中寻与name匹配的音频并播放
    /// </summary>
    /// <param name="name">音效名称</param>
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound,x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    /// <summary>
    /// 开关音乐
    /// </summary>
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    /// <summary>
    /// 开关音效
    /// </summary>
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    /// <summary>
    /// 调整音乐音量为volume
    /// </summary>
    /// <param name="volume">音量</param>
    public void MusciVolume(float volume)
    {
        musicSource.volume = volume;
    }

    /// <summary>
    /// 调整音效音量为volume
    /// </summary>
    /// <param name="volume">音量</param>
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
