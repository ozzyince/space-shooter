using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _powerupSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayLaserSound()
    {
        Invoke("InternalPlayLaserSound", 0.05f);
    }

    private void InternalPlayLaserSound()
    {
        _audioSource.PlayOneShot(_laserSound);
    }

    public void PlayExplosionSound()
    {
        Invoke("InternalPlayExplosionSound", 0.05f);
    }

    private void InternalPlayExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);
    }

    public void PlayPowerupSound()
    {
        Invoke("InternalPlayPowerupSound", 0.05f);
    }

    private void InternalPlayPowerupSound()
    {
        _audioSource.PlayOneShot(_powerupSound);
    }
}
