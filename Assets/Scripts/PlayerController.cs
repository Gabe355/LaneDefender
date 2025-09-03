using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerFireRate;
    [SerializeField] private GameObject bullet;
    private Vector2 direction;
    private InputAction move;
    private InputAction restart;
    private InputAction shoot;
    private Rigidbody2D rb;
    public bool canShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput.currentActionMap.Enable();
        rb = GetComponent<Rigidbody2D>();
        move = playerInput.currentActionMap.FindAction("Move");
        shoot = playerInput.currentActionMap.FindAction("Attack");

        move.started += Move_started;
        move.canceled += Move_canceled;

        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        CancelInvoke("IsShooting");
        canShoot = false;
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        canShoot = true;
        if(canShoot)
        {
            InvokeRepeating("IsShooting", 0f, playerFireRate);
        }
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        direction.y = 0;  
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();   
    }
    private void IsShooting()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(rb.linearVelocity.x, playerSpeed * direction.y);    
    }
    private void OnDestroy()
    {
        move.started -= Move_started;   
        move.canceled -= Move_canceled;
        shoot.started -= Shoot_started;
        shoot.canceled -= Shoot_canceled;   
    }
}
