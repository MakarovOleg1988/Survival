using System.Collections;
using UnityEngine;

namespace Survival
{
    public class SpawnEnemyFlesh : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemy;

        private Transform _spawnPoint;

        [Space, SerializeField] 
        private int _volumeEnemy;
        
        [SerializeField, Range(1f, 20f)] 
        private float _minSecTimer;
        
        [SerializeField, Range(25f, 40f)] 
        private float _maxSecTimer;
        
        [SerializeField, Range(1f, 100f)] 
        private float _timebetweenSpawn;

        private bool _enemyCanSpawn = true;
        private bool EnemyCanSpawn => _enemyCanSpawn == false;

        private void Start()
        {
            _spawnPoint = GetComponent<Transform>();
        }

        private void Update()
        {
            SpawnEnemy();
        }

        public void SpawnEnemy()
        {
            for (int i = 0; i < _volumeEnemy; i++)
            {
                if (EnemyCanSpawn) return;
                {
                    GameObject enemy = Instantiate(_enemy, _spawnPoint.transform.position, Quaternion.identity);
                    enemy.transform.parent = transform;
                    StartCoroutine(Timer());
                }
            }
        }

        private IEnumerator Timer()
        {
            _enemyCanSpawn = false;
            _timebetweenSpawn = Random.Range(_minSecTimer, _maxSecTimer);
            yield return new WaitForSeconds(_timebetweenSpawn);
            _enemyCanSpawn = true;
        }
    }
}