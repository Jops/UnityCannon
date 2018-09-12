using UnityEngine;

namespace FinishedExample
{
    public class DestroySelf : MonoBehaviour
    {
        [Tooltip( "Time To Live" )]
        public float TTL = 5f;

        public void Start()
        {
            Destroy( gameObject, TTL );
        }
    }
}
