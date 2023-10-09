using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerMovement player;

    public Text currentScore;
    public Text highScore;
    public Text Jcount;

    public int TempScore;
    public int TempHighScore;
    public int TempJCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TempScore = player.score;
        TempHighScore = player.highscore;
        TempJCount = player.JumpCount;

        currentScore.text = TempScore.ToString();
        highScore.text = TempHighScore.ToString();
        Jcount.text = (TempJCount.ToString() + " Jumps");
    }
}
