using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject levelChanger;
    public void StartNew()
    {
        levelChanger.GetComponent<LevelChanger>().FadeToNext();
    }
}
