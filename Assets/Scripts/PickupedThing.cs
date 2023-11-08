using UnityEngine;

public class PickupedThing : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
