using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public int coinsCollected;
    private Rigidbody2D rb2d;
    public GameObject score;

    private bool isGrounded;
    private float moveInput;

    private void Awake()
    {
        speed = 5f;
        jumpForce = 7f;
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
        coinsCollected = 0;
    }

    private void Update()
    {
        Moving();
        UpdateScore();
    }

    private void Moving()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    private void UpdateScore()
    {
        score.GetComponent<UnityEngine.UI.Text>().text = "Score: " + coinsCollected.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            isGrounded = true;
        if (collision.gameObject.tag == "enemy")
            ApplyDamage();
        if (collision.gameObject.tag == "coin")
        {
            coinsCollected++;
            Destroy(collision.gameObject);
            
        }
    }
    //наколхозил пздц тут, соррян, не знаю как передавать события 
    public void ApplyDamage()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

}