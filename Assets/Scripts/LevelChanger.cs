using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator fadeAnimator;

    public void FadeToNext()
    {
        fadeAnimator.SetTrigger("Fade Out");
    }

    public void FadeOutBool()
    {
        fadeAnimator.SetBool("Fade Out", true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeIn()
    {
        fadeAnimator.SetTrigger("Fade In");

    }

    public void FadeInBool()
    {
        fadeAnimator.SetBool("Fade Out", false);
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene("CauldronScene");
    }
}
