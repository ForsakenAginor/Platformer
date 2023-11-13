using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnotherMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CircleCollider2D _groundCheckCollider;
    [SerializeField] private LayerMask _ground;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Vector3 _xMovement;
    private bool _isOnGround;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _xMovement = new Vector3(1 * _speed, 0, 0);
    }

    private void Update()
    {
        CheckingGround();

        if (Input.GetKeyDown(KeyCode.W) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_xMovement * Time.deltaTime);
            _animator.SetBool("IsRunning", true);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_xMovement * Time.deltaTime * (-1));
            _animator.SetBool("IsRunning", true);
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    private void CheckingGround()
    {
        if (_groundCheckCollider != null)
        {
            _isOnGround = Physics2D.OverlapCircle(_groundCheckCollider.transform.position, _groundCheckCollider.radius, _ground);
            _animator.SetBool("IsOnGround", _isOnGround);
        }
    }
}

