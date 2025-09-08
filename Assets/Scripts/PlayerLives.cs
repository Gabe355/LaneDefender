using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private AudioSource dmg;
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
    public void TakeDamage()
    {
        lives -= 1;
        livesText.text = "Lives " + lives.ToString();
        dmg.Play();
        if(lives<= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }
    }
}
