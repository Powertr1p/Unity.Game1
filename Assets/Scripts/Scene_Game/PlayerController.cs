using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeedPerUnit;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private float _keyboardMoveInput;
    private Rigidbody2D _rb2d;

    public event UnityAction OnPlayerDeath;
    public event UnityAction CoinCollected;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _jumpForce = 7.0f;
        _moveSpeedPerUnit = 5.0f;
        _isGrounded = true;
    }

    private void FixedUpdate()
    {
        MovingPlayer();
    }

    private void MovingPlayer()
    {
        _keyboardMoveInput = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(_keyboardMoveInput * _moveSpeedPerUnit, _rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb2d.velocity = Vector2.up * _jumpForce;
            _isGrounded = false;
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Если у объектов есть только тэг и имя, без скрипта внутри, как еще их можно определять?
        if (collision.gameObject.tag == "ground")
            _isGrounded = true;
        else if (collision.gameObject.GetComponent<SawInfiniteRotation>() != null)
            ApplyDamage();
        else if (collision.gameObject.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            if (CoinCollected != null)
                CoinCollected.Invoke();
        }
    }
    
    public void ApplyDamage()
    {
        Destroy(gameObject);
        if (OnPlayerDeath != null)
            OnPlayerDeath.Invoke();
    }

}