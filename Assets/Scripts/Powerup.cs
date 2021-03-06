﻿using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int powerupId;

    private Player _player;
    private AudioManager _audioManager;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -8f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.ActivatePowerup(powerupId);
            _audioManager.PlayPowerupSound();
            Destroy(gameObject);
        }
    }
}
