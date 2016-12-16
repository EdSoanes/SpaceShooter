using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper Instance;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void CreateParticleEffect(Vector3 position, ParticleSystem particleEffect)
    {
        if (particleEffect != null)
        {
            var particleSystem = InstantiateParticleEffect(particleEffect, position);
            SetParticleEffectSortingLayer(particleSystem, "Effects");
        }
    }

    public void SetParticleEffectSortingLayer(ParticleSystem particleSystem, string sortingLayerName)
    {
        var renderers = particleSystem.GetComponentsInChildren<ParticleSystemRenderer>();
        foreach (var renderer in renderers)
            renderer.sortingLayerName = sortingLayerName;
    }

    public void PlaySound(AudioClip sound)
    {
        if (sound != null)
            GetComponent<AudioSource>().PlayOneShot(sound);
    }

    /// <summary>
    /// Instantiate a Particle system from prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private ParticleSystem InstantiateParticleEffect(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}