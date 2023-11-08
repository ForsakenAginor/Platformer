using UnityEngine;

public class Resetter : MonoBehaviour
{
    private Vector3 _starterPosition = new Vector3(-7, -3, 0);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyPatroller patroller))
            transform.position = _starterPosition;
    }
}
