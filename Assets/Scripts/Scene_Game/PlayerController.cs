using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private float _moveInput;
    private Rigidbody2D _rb2d;

    public int CoinsCollected;
    public GameObject Score;

    private void Awake()
    {
        _moveSpeed = 5f;
        _jumpForce = 7f;
        _rb2d = GetComponent<Rigidbody2D>();
        _isGrounded = true;
        CoinsCollected = 0;
    }

    private void Update()
    {
        Moving();
        UpdateScore();
    }

    private void Moving()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(_moveInput * _moveSpeed, _rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb2d.velocity = Vector2.up * _jumpForce;
            _isGrounded = false;
        }
    }

    private void UpdateScore()
    {
        Score.GetComponent<UnityEngine.UI.Text>().text = "Score: " + CoinsCollected.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Если у объектов есть только тэг и имя, без скрипта внутри, как еще их можно определять?
        if (collision.gameObject.tag == "ground")
            _isGrounded = true;
        if (collision.gameObject.tag == "enemy")
            ApplyDamage();
        if (collision.gameObject.tag == "coin")
        {
            CoinsCollected++;
            Destroy(collision.gameObject);
        }
    }
    
    //Здесь колхоз дикий, но я все еще не совсем понимаю как передавать сообщения в объекты, о которых наш класс не должен знать.
    public void ApplyDamage()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

}