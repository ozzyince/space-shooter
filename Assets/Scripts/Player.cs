using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _singleLaserPrefab;
    [SerializeField] private GameObject _tripleLaserPrefab;
    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private int _lives = 3;

    private float _nextFire;
    [SerializeField] private bool _isTripleLaserActive = false;

    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

    private void Fire()
    {
        if (Time.time < _nextFire) return;
        _nextFire = Time.time + _fireRate;
        Instantiate(_isTripleLaserActive ? _tripleLaserPrefab : _singleLaserPrefab, transform.position, Quaternion.identity);
    }

    private void CalculateMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate((Vector3.right * horizontal + Vector3.up * vertical) * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x > 11.3f ? -11.3f : transform.position.x < -11.3f ? 11.3f : transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), 0f);
    }

    public void Damage()
    {        
        if (--_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void ActivateTripleLaser()
    {
        _isTripleLaserActive = true;
        StopCoroutine("DeactivateTripleLaser");
        StartCoroutine("DeactivateTripleLaser");
    }

    IEnumerator DeactivateTripleLaser()
    {
        yield return new WaitForSeconds(5f);
        _isTripleLaserActive = false;
    }
}
