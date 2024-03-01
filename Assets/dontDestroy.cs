using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public static dontDestroy instanceUI;
    void Awake()
    {
        if (instanceUI == null)
        {
            // if instance is null, store a reference to this instance
            instanceUI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }
}
