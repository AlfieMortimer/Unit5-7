using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SceneValues : MonoBehaviour
{
    //Graphics
    public TMP_Dropdown Graphics;

    //Difficulty
    public TMP_Dropdown Difficulty;


    //Audio Mixer
    public AudioMixer MasterMixer;

    //Audio Sliders
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;


    //Audio Values
    public float Master;
    public float Music;
    public float SFX;

    void Start()
    {
        Master = PlayerPrefs.GetFloat("Master");
        Music = PlayerPrefs.GetFloat("Music");
        SFX = PlayerPrefs.GetFloat("SFX");

        Graphics.value = PlayerPrefs.GetInt("GraphicsValue");
        Difficulty.value = PlayerPrefs.GetInt("DifficultyValue");

        MasterMixer.SetFloat("Master", Master);
        MasterMixer.SetFloat("Music", Music);
        MasterMixer.SetFloat("Sound Effects", SFX);
    }
    public void SetValueMaster(float volume)
    {
        Master = volume;
        PlayerPrefs.SetFloat("Master", Master);
        MasterMixer.SetFloat("Master", Master);
    }
    public void SetValueMusic(float volume)
    {
        Music = volume;
        PlayerPrefs.SetFloat("Music", Music);
        MasterMixer.SetFloat("Music", Music);
    }
    public void SetValueSFX(float volume)
    {
        SFX = volume;
        PlayerPrefs.SetFloat("SFX", SFX);
        MasterMixer.SetFloat("Sound Effects", SFX);
    }

    public void Graphicssave()
    {
        PlayerPrefs.SetInt("GraphicsValue", Graphics.value);
    }
    public void DifficultySave()
    {
        PlayerPrefs.SetInt("DifficultyValue", Difficulty.value);
    }
}
