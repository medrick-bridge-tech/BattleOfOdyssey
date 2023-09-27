using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyPathConfig pathConfig;
        
        private PatrolAgent _patrolAgent;
        private DetectorAgent _detectorAgent;
        private Animator _animator;
        private Enemy _enemy;
        private Music _music;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool("IsAlive",true);
            _enemy = gameObject.GetComponent<global::Enemy.Enemy>();
            _patrolAgent = GetComponent<PatrolAgent>();
            _detectorAgent = GetComponent<DetectorAgent>();
            _music = FindObjectOfType<Music>();
        }

        public void SetWaveConfig(EnemyPathConfig pathConfig)
        {
            this.pathConfig = pathConfig;
        }

        private void FixedUpdate()
        {
            HandleDeath();
        }

        private void HandleDeath()
        {
            if (_enemy.EnemyHealth <= 0f)
            {
                _animator.SetBool("IsAlive",false);
                GameManager.Instance.AddCoin(1);
                GameManager.Instance.AddKill();
                Destroy(GetComponent<EnemyController>());
                PlayRandomDeathSound();
            }
        }

        private void PlayRandomDeathSound()
        {
            var randomNumber = Random.Range(0, _music.DeathSounds.Length);
            AudioSource.PlayClipAtPoint(_music.DeathSounds[randomNumber],Camera.main.transform.position,10f);
            Debug.Log($"I played {_music.DeathSounds[randomNumber].name}");
        }
    }
}