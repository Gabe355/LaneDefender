using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private TMP_Text livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            TakeDamage();  
            Destroy(collision.gameObject);  
        }
    }
    private void TakeDamage()
    {
        lives -= 1;
        livesText.text = "Lives " + lives.ToString();
    }
}
