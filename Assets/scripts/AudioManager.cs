using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudio;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource fireCrackle;
    [SerializeField] AudioSource SFXSource;

    public AudioClip menuMusic;
    public AudioClip clickSFX1;
    public AudioClip clickSFX2;
    public AudioClip FireLoop;

    void Awake()
    {
        if (instanceAudio == null)
        {
            // if instance is null, store a reference to this instance
            instanceAudio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

        musicSource.clip = menuMusic;
        musicSource.Play();
        fireCrackle.clip = FireLoop;
        fireCrackle.Play();
        
    }

    public void playsfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
//how do you manage the audio ni the audio nameager to mange the audo thath no want to be manged by the manger tat wats not be mangered wit haudo.