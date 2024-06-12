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
        musicSource.clip = background; // ������� ��� (Ŭ���� ���� ����)
        musicSource.Play(); // �÷��� 
    }

    public void PlaySFX(AudioClip clip) // Ŭ���� �Ű������� ����� �ٸ� ��ũ��Ʈ���� ������!
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
