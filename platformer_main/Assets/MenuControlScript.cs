using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
