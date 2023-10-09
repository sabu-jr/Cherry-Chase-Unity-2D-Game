using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject player;
    public GameObject allEnemies;
    public GameObject Cherries;

    public GameObject gameOverCanvas;
    public PlayerMovement Score;
    public bool GameHasEnded = false;

    void Start()
    {
        allEnemies.SetActive(true);
        Cherries.SetActive(true);
    }

    public void EndGame()
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            Debug.Log("GAME OVER!");

            //player.SetActive(false);
            allEnemies.SetActive(false);
            Cherries.SetActive(false);

            gameOverCanvas.SetActive(true);
        }
    }
    public void RestartGame()
    {
        Score.score = 0;
        Score.JumpCount = 0;
        player.transform.position = new Vector3(-7.28186f, 0.01f, -0.0960207f);
        Score.GameStarted = false;
        GameHasEnded = false;
        gameOverCanvas.SetActive(false);

        //player.SetActive(true);
        allEnemies.SetActive(true);
        Cherries.SetActive(true);

    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("EXITING THE GAME!");
    }
}
