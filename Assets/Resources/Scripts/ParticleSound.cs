using System.Collections;
using UnityEngine;

public class ParticleSound : MonoBehaviour
{
    public float soundDelay = 0.1f; 
    public AudioClip[] audioExplosion; 

    void LateUpdate()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[GetComponent<ParticleSystem>().particleCount];
        int length = GetComponent<ParticleSystem>().GetParticles(particles);

        for (int i = 0; i < length; i++)
        {
            if (particles[i].remainingLifetime < soundDelay)
            {
                AudioClip clip = audioExplosion[Random.Range(0, audioExplosion.Length)];

                AudioSource.PlayClipAtPoint(clip, particles[i].position);
            }
        }
    }
}
  