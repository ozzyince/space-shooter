using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
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
            DamagePlayer(collision);
        Destroy(gameObject);
    }

    private void DamagePlayer(Collider2D collision)
    {
        _player.Damage();
    }
}
