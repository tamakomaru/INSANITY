using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManeger : MonoBehaviour
{
    public static AudioManeger instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic, bossBattle, bossEX;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f,1.1f);

        soundEffects[soundToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        bossBattle.Stop();
        bgm.Stop();

        levelEndMusic.Play();
    }

    public void PlayBossBattle()
    {  
        bgm.Stop();
        bossBattle.Play();
    }

    public void StopBossBattle()
    {  
        bossBattle.Stop();
        bgm.Play();
    }






}
