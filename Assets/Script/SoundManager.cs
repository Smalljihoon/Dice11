using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public  static SoundManager instance;

    public AudioClip warning;
    public AudioClip enemyDie;
    public AudioClip hpDown;

    AudioSource myAudio;

    private void Awake()
    {
        if(SoundManager.instance == null) 
        {
            SoundManager.instance = this;
        }
    }

    private void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }

    public void Warning()
    {
        myAudio.PlayOneShot(warning);
    }

    public void EnemyDie()
    {
        myAudio.PlayOneShot(enemyDie);
    }

    public void HpDown()
    {
        myAudio.PlayOneShot(hpDown);
    }
}
