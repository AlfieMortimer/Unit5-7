using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Animator transition;

    //Graphics
    public TMPro.TMP_Dropdown Graphics;

    //Difficulty
    public TMPro.TMP_Dropdown Difficulty;


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

    //singleton
    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }

    void Start()
    {
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
    public void toggleMute()
    {

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
    }
}
