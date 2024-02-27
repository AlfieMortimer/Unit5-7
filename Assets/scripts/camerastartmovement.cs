using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camerastartmovement : MonoBehaviour
{
    public LevelManager LevelManager;
    public AudioManager audioManager;
    public GameObject Target;
    public GameObject Door;
    public GameObject DoorTarget;
    public AudioClip Dooropen;

    bool canmove = false;
    bool doormove = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            float step = 3 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
            transform.eulerAngles = Vector3.zero;
            
        }
        if (doormove)
        {
            float step = 2 * Time.deltaTime;
            Door.transform.position = Vector3.MoveTowards(Door.transform.position, DoorTarget.transform.position, step);
        }
    }
    public void Startsequence()
    {
        canmove = true;
        print("CameraMove");
        StartCoroutine(waitfortransition());
    }
    public void doorLift()
    {
        doormove = true;
        audioManager.playsfx(Dooropen);
    }
    IEnumerator waitfortransition()
    {
        yield return new WaitForSeconds(2);
        LevelManager.loadNextLevel();
    }
}
