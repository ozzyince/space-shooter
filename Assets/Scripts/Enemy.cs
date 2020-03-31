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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
            Destroy(other.gameObject);
        else if (other.CompareTag("Player"))
            DamagePlayer(other);
        Destroy(gameObject);
    }

    private void DamagePlayer(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
            player.Damage();
    }
}
