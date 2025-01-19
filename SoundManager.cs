using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public AudioClip[] sfxClip;

    public Slider sfxSlider;
    public Slider bgmSlider;

    void Start()
    {
        bgmPlayer.volume = GameManager.instance.saveData.bgm;
        sfxPlayer.volume = GameManager.instance.saveData.sfx;
        bgmSlider.value = GameManager.instance.saveData.bgm;
        sfxSlider.value = GameManager.instance.saveData.sfx;
    }
    
    public void PlaySfx(int n)
    {
        sfxPlayer.PlayOneShot(sfxClip[n]);
    }

    public void SetSlider()
    {
        GameManager.instance.saveData.sfx = sfxSlider.value;
        GameManager.instance.saveData.bgm = bgmSlider.value;
        bgmPlayer.volume = GameManager.instance.saveData.bgm;
        sfxPlayer.volume = GameManager.instance.saveData.sfx;
    }
}
