using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private Image healthBar;
    private ScoreController scoreController;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        scoreController = GameObject.FindFirstObjectByType<ScoreController>();  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            TakeDmg(1f);
            Destroy(collision.gameObject);  
        }
    }
    private void TakeDmg(float dmg)
    {
        enemyCurrentHealth -= dmg;
        healthBar.fillAmount = enemyCurrentHealth / enemyMaxHealth;
        if(enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
            scoreController.IncreaseScore(100f * enemyMaxHealth);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
