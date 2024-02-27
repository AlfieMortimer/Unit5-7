using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public Animator transition;
   public void returnToMenu()
    {
        StartCoroutine(Return());
    }

    IEnumerator Return()
    {
        transition.SetTrigger("Transition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);
    }
}
