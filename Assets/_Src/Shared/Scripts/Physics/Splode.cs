using UnityEngine;

public class Splode : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public float uplift = 1f;

    public void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere( explosionPos, radius );
        foreach( Collider hit in colliders )
        {
            Rigidbody rigidBody = hit.GetComponent<Rigidbody>();

            if( rigidBody != null )
                rigidBody.AddExplosionForce( power, explosionPos, radius, uplift );
        }
    }
}
