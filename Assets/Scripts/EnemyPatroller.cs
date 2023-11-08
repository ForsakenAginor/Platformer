using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(BoxCollider2D))]
public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private float _speed = 1;
    private Transform[] _points;
    private int _currentTargetIndex;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentTargetIndex].position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentTargetIndex++;

        if( _currentTargetIndex == _points.Length )
            _currentTargetIndex = 0;

        if(_points[_currentTargetIndex].position.x < transform.position.x && _spriteRenderer.flipX == false)
            _spriteRenderer.flipX = true;

        if (_points[_currentTargetIndex].position.x > transform.position.x && _spriteRenderer.flipX == true)
            _spriteRenderer.flipX = false;
    }
}
