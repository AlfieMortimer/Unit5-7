using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip menuMusic;
    public AudioClip clickSFX;

    // Start is called before the first frame update
    private void Start()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void playsfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
//how do you manage the audio ni the audio nameager to mange the audo thath no want to be manged by the manger tat wats not be mangered wit haudo.