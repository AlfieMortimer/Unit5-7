using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneValues : MonoBehaviour
{
    public static LevelManager instance;
    public Animator transition;

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

    //mute toggle
    bool ismuted;

    void Start()
    {

        transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();

        Master = PlayerPrefs.GetFloat("Master");
        Music = PlayerPrefs.GetFloat("Music");
        SFX = PlayerPrefs.GetFloat("SFX");
        
        MasterSlider.value = Master;
        MusicSlider.value = Music;
        SFXSlider.value = SFX;
        
        Graphics.value = PlayerPrefs.GetInt("GraphicsValue");
        Difficulty.value = PlayerPrefs.GetInt("DifficultyValue");

        MasterMixer.SetFloat("Master", Master);
        MasterMixer.SetFloat("Music", Music);
        MasterMixer.SetFloat("Sound Effects", SFX);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetValueMaster()
    {
        Master = MasterSlider.value;
        PlayerPrefs.SetFloat("Master", Master);
        MasterMixer.SetFloat("Master", Master);
    }
    public void loadMusic()
    {
        Music = PlayerPrefs.GetFloat("Music");

    }
    public void SetValueMusic()
    {
        if (ismuted == false)
        {
            Music = MusicSlider.value ;
            PlayerPrefs.SetFloat("Music", Music);
            MasterMixer.SetFloat("Music", Music);
        }
    }
    public void SetValueSFX()
    {
        SFX = SFXSlider.value;
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
    public void quitGame()
    {
        Application.Quit();
        print("QuitGame");
    }

    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Transition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);

        transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();
        print(transition.name);

    }
    public void returnToMenu()
    {
        StartCoroutine(Return());
    }

    public void Mutetoggle(bool muted)
    {
        if (muted)
        {
            MasterMixer.SetFloat("Music", -80);
            ismuted = true;
        }
        else
        {
            loadMusic();
            ismuted = false;
            SetValueMusic();
        }
    }
    IEnumerator Return()
    {
        transition.SetTrigger("Transition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(0.5f);

        transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();
        if (transition != null)
        {
            print(transition.name);
        }

    }

}
