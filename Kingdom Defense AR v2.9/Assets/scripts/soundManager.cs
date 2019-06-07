using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {
    public AudioSource soundSwipeSFX;
    public AudioSource soundTouchedButtonGameSFX;
    public AudioSource soundArrowShootSFX;
    public AudioSource soundMoneyGainedSFX;
    public AudioSource soundEndRoundSFX;
    private AudioSource soundExplosionSFX;

    // Use this for initialization
    void Start () {
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        soundSwipeSFX = audioSources[1];
        soundTouchedButtonGameSFX = audioSources[2];
        soundArrowShootSFX = audioSources[3];
        soundMoneyGainedSFX = audioSources[4];
        soundEndRoundSFX = audioSources[5];
        soundExplosionSFX = audioSources[6];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSoundSwipe()
    {
        soundSwipeSFX.PlayOneShot(soundSwipeSFX.clip);
    }

    public void playSoundButton()
    {
        soundTouchedButtonGameSFX.PlayOneShot(soundTouchedButtonGameSFX.clip);
    }

    public void playSoundArrowShoot()
    {
        soundArrowShootSFX.PlayOneShot(soundArrowShootSFX.clip);
    }

    public void playSoundMoneyGained()
    {
        soundMoneyGainedSFX.PlayOneShot(soundMoneyGainedSFX.clip);
    }

    public void playSoundEndRound()
    {
        soundEndRoundSFX.PlayOneShot(soundEndRoundSFX.clip);
    }

    public void playExplosionSoundEffect()
    {
        soundExplosionSFX.PlayOneShot(soundExplosionSFX.clip);
    }

}
