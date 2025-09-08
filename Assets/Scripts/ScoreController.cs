using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    private float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore",0).ToString();
    }
    public void IncreaseScore(float scoreUp)
    {
        score += scoreUp;       
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScoreText.text = "HighScore: " + score.ToString();
        }
    }
}
