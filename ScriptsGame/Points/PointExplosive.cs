using UnityEngine;

public class PointExplosive : MonoBehaviour
{
    [SerializeField] private AudioSource pointExplosiveSoundClip;
    [SerializeField] private ParticleSystem pointExplosiveEffectSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pointExplosiveSoundClip.Play();
            pointExplosiveEffectSource.Play();
            Destroy(gameObject, pointExplosiveSoundClip.clip.length);
        }
    }
}

