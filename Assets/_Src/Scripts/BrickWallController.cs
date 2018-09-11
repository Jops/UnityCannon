using UnityEngine;

public class BrickWallController : MonoBehaviour
{
    private int m_count;
    private Vector3[] m_posOrigs;
    private Quaternion[] m_rotOrigs;

    public void Start()
	{
        m_count = transform.childCount;

        m_posOrigs = new Vector3[ m_count ];
        m_rotOrigs = new Quaternion[ m_count ];

        for( int i = 0; i < m_count; i++ )
        {
            m_posOrigs[ i ] = transform.GetChild( i ).position;
            m_rotOrigs[ i ] = transform.GetChild( i ).rotation;
        }
    }
	
	public void Reset()
	{
        Rigidbody rigidbody;
        for( int i = 0; i < m_count;  i++ )
        {
            rigidbody = transform.GetChild( i ).GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.MovePosition( m_posOrigs[ i ] );
            rigidbody.MoveRotation( m_rotOrigs[ i ] );
        }
	}
}
