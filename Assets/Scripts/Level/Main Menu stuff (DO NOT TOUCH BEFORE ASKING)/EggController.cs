using UnityEngine;
using UnityEngine.Audio;

public class EggController : MonoBehaviour
{

    private AudioSource _audioSource;
    [SerializeField] GameObject _full;
    [SerializeField] GameObject _damaged;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void Hatch()
    {
         Destroy();
    }

    public void Clear()
    {
        _full.gameObject.SetActive(true);
        _damaged.gameObject.SetActive(false); 
    }
    public void Destroy()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
            _full.gameObject.SetActive(false);
            _damaged.gameObject.SetActive(true);
            _particleSystem.Play();
        }
    }

}