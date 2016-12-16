using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    public ParticleSystem deathEffect;
    public AudioClip deathSound;
    public ParticleSystem hitEffect;
    public AudioClip hitSound;

    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;
    private int currentHp;
    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    void Start()
    {
        currentHp = hp;
    }

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        currentHp -= damageCount;

        if (currentHp <= 0)
        {
            SpecialEffectsHelper.Instance.CreateParticleEffect(transform.position, deathEffect);
            SpecialEffectsHelper.Instance.PlaySound(deathSound);
            // Dead!
            Destroy(gameObject);

            if (isEnemy)
                HUD.Instance.AddToScore(hp);
            else
            {
                HUD.Instance.HaltGameTime();
                HUD.Instance.LoseGame();
            }
        }
        else
        {
            SpecialEffectsHelper.Instance.CreateParticleEffect(transform.position, hitEffect);
            SpecialEffectsHelper.Instance.PlaySound(hitSound);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
}