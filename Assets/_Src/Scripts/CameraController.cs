using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float smoothing = 1f;
    public Transform defaultTarget;

    private Vector3 m_lookAt;

    public void Awake()
    {
        if( instance == null ) instance = this;
        else if( instance != this ) Destroy( gameObject );
    }

    public void Start()
    {
        LookToward( defaultTarget );
    }

    public void LookToward( Transform target )
    {
        StopAllCoroutines();
        StartCoroutine( Looking( target ) );
    }

    private IEnumerator Looking( Transform t )
    {
        while( t )
        {
            m_lookAt = Vector3.Lerp( m_lookAt, t.position, smoothing * Time.deltaTime );
            transform.LookAt( m_lookAt );

            yield return null;
        }

        LookToward( defaultTarget );
    }
}
