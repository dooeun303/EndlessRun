using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip background;
    public AudioClip die;
    public AudioClip jump;
    public AudioClip coin;

    private void Start()
    {
        musicSource.clip = background; // 배경음악 재생 (클립에 변수 지정)
        musicSource.Play(); // 플레이 
    }

    public void PlaySFX(AudioClip clip) // 클립을 매개변수로 사용해 다른 스크립트에서 음향사용!
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
