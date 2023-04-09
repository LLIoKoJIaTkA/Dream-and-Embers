using UnityEngine;

namespace MainScripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offcet;
        [SerializeField] private float smoothing = 3f;
        
        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var nextPosition = Vector3.Lerp(transform.position, targetTransform.position + offcet, Time.fixedDeltaTime * smoothing);
            transform.position = nextPosition;
        }
    }
}