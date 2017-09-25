using UnityEngine;

[System.Serializable]
/*
 * Generic properties for a character's stats
 */
public class CharacterStats : MonoBehaviour
{
    protected int m_maxHealth;

    [SerializeField]
    protected int m_currHealth;

    public int MaxHealth
    {
        get { return m_maxHealth; }
        set { m_maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return m_currHealth; }
        private set { m_currHealth = value; }
    }
    

    public void Awake()
    {
        m_currHealth = m_maxHealth;
    }

    public void InitializeHealth(int max)
    {
        m_maxHealth = max;
        m_currHealth = m_maxHealth;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmt)
    {
        // Don't allow the damage amount to go below zero
        damageAmt = Mathf.Clamp(damageAmt, 0, int.MaxValue);

        m_currHealth -= damageAmt;

        Debug.Log(transform.name + "takes " + damageAmt + " damage");

        if (m_currHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Play character's death animations, and respawn, etc....
    }
}
