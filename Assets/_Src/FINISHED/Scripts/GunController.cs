using UnityEngine;

namespace FinishedExample
{
    public class GunController : MonoBehaviour
    {
        public Transform barrelPoint;
        public GameObject shotPrefab;
        [Header( "Blast Effect" )]
        public Vector3 blastForce = new Vector3( 0f, 0f, 100f );
        public GameObject barrelBlastPrefab;
        
        private GameObject m_shot;
        
        public void Fire()
        {
            m_shot = Instantiate( shotPrefab, barrelPoint.position, barrelPoint.rotation );
            Blast();
            
            CameraController.instance.LookToward( m_shot.transform );
        }
        
        private void Blast()
        {
            m_shot.GetComponent<Rigidbody>().AddRelativeForce( blastForce );
            Instantiate( barrelBlastPrefab, barrelPoint.position, barrelPoint.rotation );
        }
    }
}