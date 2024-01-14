using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator fadeAnimator;

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToNext()
    {
        fadeAnimator.SetTrigger("Fade Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeIn()
    {
        fadeAnimator.SetTrigger("Fade In");
    }
}
