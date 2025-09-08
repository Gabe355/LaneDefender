using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject hitMarker;
    private Rigidbody2D rb;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(bulletSpeed, rb.linearVelocityY);
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Instantiate(hitMarker,transform.position,Quaternion.identity);
        }
    }
}
