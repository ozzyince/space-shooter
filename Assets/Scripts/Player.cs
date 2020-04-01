using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _singleLaserPrefab;
    [SerializeField] private GameObject _tripleLaserPrefab;
    [SerializeField] private GameObject _shield;
    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private int _lives = 3;

    private float _nextFire;
    [SerializeField] private bool _isTripleLaserActive = false;
    [SerializeField] private bool _isSpeedActive = false;

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
        transform.Translate((Vector3.right * horizontal + Vector3.up * vertical) * (_isSpeedActive ? 2 : 1) * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x > 11.3f ? -11.3f : transform.position.x < -11.3f ? 11.3f : transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), 0f);
    }

    public void Damage()
    {
        if (_shield.activeInHierarchy)
        {
            _shield.SetActive(false);
            return;
        }
        if (--_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void ActivatePowerup(int powerupId)
    {
        switch (powerupId)
        {
            case 0: ActivateTripleLaser(); break;
            case 1: ActivateSpeed(); break;
            case 2: ActivateShield(); break;
            default: break;
        }
    }

    private void ActivateShield()
    {
        _shield.SetActive(true);
        StopCoroutine("DeactivateShield");
        StartCoroutine("DeactivateShield");
    }

    private void ActivateSpeed()
    {
        _isSpeedActive = true;
        StopCoroutine("DeactivateSpeed");
        StartCoroutine("DeactivateSpeed");
    }

    private void ActivateTripleLaser()
    {
        _isTripleLaserActive = true;
        StopCoroutine("DeactivateTripleLaser");
        StartCoroutine("DeactivateTripleLaser");
    }

    private IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(5f);
        _shield.SetActive(false);
    }

    private IEnumerator DeactivateSpeed()
    {
        yield return new WaitForSeconds(5f);
        _isSpeedActive = false;
    }

    private IEnumerator DeactivateTripleLaser()
    {
        yield return new WaitForSeconds(5f);
        _isTripleLaserActive = false;
    }
}
