using UnityEngine;

public class Pickuper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PickupedThing>(out PickupedThing thing))
            thing.Destroy();
    }
}
