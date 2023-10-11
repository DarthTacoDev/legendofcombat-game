using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    public Animator transition;

    public float transitionTime = 1.5f;

    public void SceneTransition()
    {
        StartCoroutine(SceneTransitionRoutine());
    }

    IEnumerator SceneTransitionRoutine()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

    }
}
