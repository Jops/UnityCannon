using UnityEngine;

public class Splode : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public float uplift = 1f;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere( explosionPos, radius );
        foreach( Collider hit in colliders )
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if( rb != null )
                rb.AddExplosionForce( power, explosionPos, radius, uplift );
        }
    }
}
