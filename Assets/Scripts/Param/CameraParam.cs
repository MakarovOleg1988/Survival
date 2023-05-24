using UnityEngine;

namespace Survival
{
    public class CameraParam: MonoBehaviour
    {
        protected Transform _playerTransform;

        [SerializeField, Range(1f, 10f)]
        protected float _speedMovementCamera;

        protected Vector3 _cameraPosition;
    }
}
