using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private AudioSource damage;
    [SerializeField] private AudioSource death;
    private ScoreController scoreController;
    private PlayerLives playerLives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        scoreController = GameObject.FindFirstObjectByType<ScoreController>();  
        playerLives = GameObject.FindFirstObjectByType<PlayerLives>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            TakeDmg(1f);
            Destroy(collision.gameObject);        
        }
        if(collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            playerLives.TakeDamage();   
        }
    }
    private void TakeDmg(float dmg)
    {
        enemyCurrentHealth -= dmg;
        healthBar.fillAmount = enemyCurrentHealth / enemyMaxHealth;
        if(enemyCurrentHealth <= 0)
        {
            Destroy(gameObject,1);
            scoreController.IncreaseScore(100f * enemyMaxHealth);
            death.Play();
        }
        else
        {
            damage.Play();
        }
          
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
