using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    IEnumerator StunEnemy(float stunTime)
    {
        enemySpeed = enemySpeed / 100;
        yield return new WaitForSeconds(stunTime); 
        enemySpeed = enemySpeed * 100;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            StartCoroutine(StunEnemy(1f));
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-enemySpeed, rb.linearVelocityY);
    }
}
