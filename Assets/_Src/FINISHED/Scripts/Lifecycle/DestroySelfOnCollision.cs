using UnityEngine;

public class DestroySelfOnCollision : MonoBehaviour
{
    public void OnCollisionEnter( Collision collision )
    {
        Destroy( gameObject );
    }
}
