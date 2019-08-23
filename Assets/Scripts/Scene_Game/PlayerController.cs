using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private bool _isGrounded = true;
    private float _moveInput;
    private Rigidbody2D _rb2d;

    private int CoinsCollected = 0;
    public GameObject Score;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moving();
        ShowScore();
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

    private void ShowScore()
    {
        Score.GetComponent<Text>().text = "Score: " + CoinsCollected.ToString();
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