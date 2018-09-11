using UnityEngine;

public class RotateContinuous : MonoBehaviour
{
    public Vector3 rotateBy = new Vector3( 0f, 1f, 0f );

    public void Update()
    {
        transform.Rotate( rotateBy * Time.deltaTime, Space.World );
    }
}
