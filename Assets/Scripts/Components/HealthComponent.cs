using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    UnityEvent OnDeath;
    UnityEvent OnHeal;
    UnityEvent OnDamage;

    public bool dead = false;
    public bool removeColliderOnDeath = false;
    [SerializeField] private float health = 100;
    [SerializeField] private float maxHealth = 100;

    public float GetHealth { get => health; }

    // If there is an animator. Set the animation flag
    // !! THIS NEED TO MOVE THE OWNER OF THIS COMPONENT
    //if (animator)
    //{
    //    animator.SetTrigger("Dead");
    //}

    public bool Heal(float healAmount)
    {
        if (health >= maxHealth)
        {
            return false;
        }

        if (dead)
        {
            return false;
        }

        if (healAmount <= 0.0f || health <= 0.0f)
        {
            return false;
        }

        health = Mathf.Clamp(health + healAmount, 0, maxHealth);
        OnHeal?.Invoke();

        return true;
    }

    public void Damage(float damage)
    {
        if (damage <= 0.0f || dead)
        {
            return;
        }

        health = Mathf.Clamp(health - damage, 0.0f, maxHealth);

        // Is the object dead
        dead = health <= 0.0f;

        if (dead)
        {
            // Remove all colliders on the object
            if (removeColliderOnDeath)
            {
                RemoveColliders(GetComponents<Collider>());
                RemoveColliders(GetComponentsInChildren<Collider>());
            }
            OnDeath?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
    }

    void RemoveColliders(Collider[] colliders)
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
