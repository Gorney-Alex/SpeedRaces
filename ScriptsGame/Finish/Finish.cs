// Gorney-Alex script

using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private AudioSource finishSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            finishEffect.Play();
            finishSound.Play();
            Debug.Log("Finished");
        }
    }
}
