using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -11f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
            Destroy(collision.gameObject);
        else if (collision.CompareTag("Player"))
            DamagePlayer(collision);
        Destroy(gameObject);
    }

    private void DamagePlayer(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            player.Damage();
    }
}
