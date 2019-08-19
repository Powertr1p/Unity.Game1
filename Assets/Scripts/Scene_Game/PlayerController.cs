using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private int _coins;

    private Rigidbody2D rb2d;

    private bool isGrounded;
    private float moveInput;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            isGrounded = true;
        if (collision.gameObject.tag == "enemy")
            ApplyDamage();
        if (collision.gameObject.tag == "coin")
        {
            _coins++;
            Destroy(collision.gameObject);
        }

    }
    // Конец игры, так как у нас одна жизнь. 
    //Я понимаю, что это не совсем правильно, но я хз как сообщить другому скрипту о смерти игрока.
    private void ApplyDamage() 
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

}