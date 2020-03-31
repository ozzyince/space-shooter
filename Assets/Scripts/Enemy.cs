using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -7f)
            transform.position = new Vector3(UnityEngine.Random.Range(-10f, 10f), 7f, 0);
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
