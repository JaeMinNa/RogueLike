using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ���� �� ������� ����

    // BGM / SFX ���� ����ϰų� ����

    // ����� ���ҽ� �ε� / ���� ���

    // �ʿ��� ȿ������ �ִٸ� �ּ����� ����� �ּ���. ���� �߰��صΰڽ��ϴ�.

    private AudioSource _backgroundMusic;
    private AudioSource _soundEffects;

    public void InitalizeAudios()
    {
        if (_backgroundMusic == null && _soundEffects == null)
        {
            _backgroundMusic = GetComponent<AudioSource>();
            _soundEffects = GetComponent<AudioSource>();
        }
    }
}
