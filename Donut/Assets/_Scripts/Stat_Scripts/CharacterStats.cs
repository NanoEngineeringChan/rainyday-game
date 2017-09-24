using UnityEngine;

[System.Serializable]

/*
 * Base Class for a stat
 */
public class CharacterStats : MonoBehaviour
{
    public int m_maxHealth { get; private set; }

    public int m_currHealth { get; private set; }

    private void Awake()
    {
        m_currHealth = m_maxHealth;
    }

    public virtual void TakeDamage(int damageAmt)
    {
        m_currHealth -= damageAmt;

        // Don't allow the current health to go below zero or above max health
        Mathf.Clamp(m_currHealth, 0, m_maxHealth);
    }
}
