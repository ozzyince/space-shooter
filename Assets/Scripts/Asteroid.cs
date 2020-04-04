using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    private float _rotationSpeed;
    private SpawnManager _spawnManager;
    private Player _player;

    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _player = FindObjectOfType<Player>();
        GetComponent<SpriteRenderer>().flipY = Random.Range(0, 2) == 1;
        _rotationSpeed = Random.Range(5f, 20f) * Mathf.Pow(-1, Random.Range(0, 2));
        var scale = Random.Range(0.5f, 1f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
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
        var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.transform.localScale = transform.localScale;
        Destroy(explosion, 3f);
        _spawnManager.OnAsteroidDestroyed();
        Destroy(gameObject);
    }
}
