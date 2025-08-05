using UnityEngine.SceneManagement;
using UnityEngine;

public class StartToMain : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("MainScenes");
    }

}
