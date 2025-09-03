using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void IncreaseScore(float scoreUp)
    {
        score += scoreUp;
        scoreText.text = score.ToString();
    }
}
