using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigations : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
