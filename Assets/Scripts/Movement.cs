using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnotherMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Vector3 _xMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _xMovement = new Vector3(1 * _speed, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _animator.Play("Jump");
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
}

