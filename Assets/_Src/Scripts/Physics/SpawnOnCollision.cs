using UnityEngine;

public class SpawnOnCollision : MonoBehaviour
{
    public GameObject prefab;

    public void OnCollisionEnter( Collision collision )
    {
        ContactPoint contact = collision.contacts[ 0 ];
        Quaternion rot = Quaternion.FromToRotation( Vector3.up, contact.normal );
        Vector3 pos = contact.point;
        Instantiate( prefab, pos, rot );
    }
}
