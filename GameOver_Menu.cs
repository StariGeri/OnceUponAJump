using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_Menu : MonoBehaviour
{
    public Text hsText;
    public Text scoreText;

    public void Start()
    {
        hsText.text = PlayerPrefs.GetFloat("HighScore",0).ToString("0");
        scoreText.text = PlayerPrefs.GetFloat("Score",0).ToString("0");
        
    }
    public void PlayGame ()
    {
         SceneManager.LoadScene("Game");
    }

    public void QuitToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
