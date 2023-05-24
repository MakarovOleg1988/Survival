using System;
using System.Collections;
using UnityEngine;

namespace Survival
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementAndAttack : PlayerParam, IEventManager
    {
        private void Awake()
        {
            _controller = new NewControls();
        }

        private void OnEnable()
        {
            _controller.NewActionMap.Enable();
            _controller.Joystick.Enable();
        }

        private void Start()
        {
            MaxHealth = CurrentHealth;
            _healthBar.value = MaxHealth - CurrentHealth;
            _healthBar.maxValue = MaxHealth;

            _currentCapacityClipRifle = _maxCapacityClipRifle;

            _rbPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
#if UNITY_EDITOR
            Vector2 delta = _controller.Joystick.Delta.ReadValue<Vector2>();
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Vector2 delta = _controller.Joystick.Delta.ReadValue<Vector2>();
#elif UNITY_ANDROID
            Vector2 delta = _controller.Joystick.Delta.ReadValue<Vector2>();
#endif
            transform.Translate(delta * SpeedMovement() * Time.deltaTime);

            transform.Translate(delta * SpeedMovement() * Time.deltaTime);
        }

        public void Shoot()
        {
            if (_canShoot == true && _currentCapacityClipRifle > 0)
            {
                IEventManager.SendSetShootRifle();
                var bullet = Instantiate(_bulletPrefab, _fireTarget.transform.position, transform.rotation);
                _currentCapacityClipRifle--;
                _canShoot = false;
            }

            StartCoroutine(TimerCoroutine());
        }

        public void ReloadGun()
        {
            IEventManager.SendSetReloadWeapon();
            _currentCapacityClipRifle = _maxCapacityClipRifle;
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(_timeBetweenShoot);
            _canShoot = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<EnemyMovementAndAttack>())
            {
                IEventManager.SendSetDamagePlayer();
                CurrentHealth--;
                Debug.Log(CurrentHealth);
                _healthBar.value = MaxHealth - CurrentHealth;
                if (CurrentHealth <= 0)
                {
                    _losePanel.SetActive(true);
                    Destroy(this.gameObject);
                }
            }

            if (collision.GetComponent<HelmetParam>())
            {
                _items[0].SetActive(true);
                _InventoryItems[0].SetActive(true);
            }
            else if (collision.GetComponent<ArmorParam>())
            {
                _items[1].SetActive(true);
                _InventoryItems[1].SetActive(true);
            }

            else if (collision.GetComponent<PantsParam>())
            {
                _items[2].SetActive(true);
                _items[3].SetActive(true);
                _InventoryItems[2].SetActive(true);
            }
        }

        private void OnDisable()
        {
            _controller.NewActionMap.Disable();
            _controller.Joystick.Disable();
        }
    }
}
