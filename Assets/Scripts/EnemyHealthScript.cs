using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
