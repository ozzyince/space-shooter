using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Player _player;
    private Animator _animator;
    private BoxCollider2D _collider;
    private AudioManager _audioManager;

    private bool _destroying = false;
    private float _baseSpeed = 0;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (_destroying)
        {
            if (_baseSpeed == 0)
                _baseSpeed = _speed;
            _speed -= _baseSpeed / 1.5f * Time.deltaTime;
        }
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -11f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            _player.AddScore();
            collision.gameObject.GetComponent<Laser>().DestroyEx();
        }
        else if (collision.CompareTag("Player"))
            _player.Damage();
        else
            return;
        _destroying = true;
        _animator.SetTrigger("OnEnemyDeath");
        _collider.enabled = false;
        _audioManager.PlayExplosionSound();
        Destroy(gameObject, 3f);
    }
}
