using UnityEngine;

namespace Survival
{
    public class CameraMovement : CameraParam
    {
        private void Awake()
        {
            _playerTransform = FindObjectOfType<PlayerMovementAndAttack>().transform;
        }

        private void LateUpdate()
        {
            Chase();
        }

        private void Chase()
        {
            if (_playerTransform == null) return;

            _cameraPosition = _playerTransform.position;
            _cameraPosition.z = -10f;
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, _speedMovementCamera * Time.deltaTime);
        }
    }
}
