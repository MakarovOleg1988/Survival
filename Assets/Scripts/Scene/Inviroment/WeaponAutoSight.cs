using UnityEngine;

namespace Survival
{
    public class WeaponAutoSight : MonoBehaviour
    {
        public float _rotationSpeed = 5f;

        private string _targetTag = "Enemy"; 

        [SerializeField]
        private Transform _player;

        private void Update()
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(_targetTag);

            GameObject nearestObject = null;
            float shortestDistance = Mathf.Infinity;
            
            foreach (GameObject obj in objectsWithTag)
            {
                float distance = Vector2.Distance(_player.position, obj.transform.position);
                if (distance < shortestDistance)
                {
                    nearestObject = obj;
                    shortestDistance = distance;
                }
            }

            if (nearestObject != null)
            {
                transform.right = nearestObject.transform.position - transform.position;
            }

            Vector3 direction = nearestObject.transform.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

    }
}