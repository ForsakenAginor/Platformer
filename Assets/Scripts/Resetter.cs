using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] private float _xPosition;
    [SerializeField] private float _yPosition;

    private Vector3 _starterPosition;

    private void Awake()
    {
        _starterPosition = new Vector3(_xPosition, _yPosition, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyPatroller patroller))
            transform.position = _starterPosition;
    }
}
