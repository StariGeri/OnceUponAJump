using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore",0).ToString("0");
    }

    void Update()
    {
        if(player.position.y > -2f)
        {
            
            float score = player.position.x;
            scoreText.text = score.ToString("0");
            PlayerPrefs.SetFloat("Score",score);
            
            if(score > PlayerPrefs.GetFloat("HighScore",0))
            {
                PlayerPrefs.SetFloat("HighScore",score);
                highScore.text = score.ToString("0");
            } 
        }
    }
}
