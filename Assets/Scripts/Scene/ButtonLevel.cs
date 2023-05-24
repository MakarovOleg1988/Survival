using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Survival
{
    class ButtonLevel: MonoBehaviour
    {
        private PlayerMovementAndAttack _playerMovementAndAttack;

        [SerializeField]
        protected GameObject _inventory;

        [SerializeField]
        protected TextMeshProUGUI _currentClipCapacitText;

        [SerializeField]
        protected TextMeshProUGUI _MaxClipCapacityText;


        private bool _isOpened = false;

        private void Start()
        {
            _playerMovementAndAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementAndAttack>();

            _MaxClipCapacityText.text = _playerMovementAndAttack._maxCapacityClipRifle.ToString();
            _currentClipCapacitText.text = _playerMovementAndAttack._currentCapacityClipRifle.ToString();
        }

        private void LateUpdate()
        {
            ChangeTitleWeapon();
        }

        public void UseInventory()
        {
            if (_isOpened == false)
            {
                _inventory.SetActive(true);
                _isOpened = true;
            }
            else if (_isOpened == true)
            {
                _inventory.SetActive(false);
                _isOpened = false;
            }
        }

        private void ChangeTitleWeapon()
        {
            _MaxClipCapacityText.text = _playerMovementAndAttack._maxCapacityClipRifle.ToString();
            _currentClipCapacitText.text = _playerMovementAndAttack._currentCapacityClipRifle.ToString();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
