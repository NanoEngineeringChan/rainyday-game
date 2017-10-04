using UnityEngine;
using System.Collections;

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
            TakeDamage(30);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RestoreHealth(20);
        }
    }

    public void TakeDamage(int damageAmt)
    {
        // Don't allow the damage amount to go below zero
        damageAmt = Mathf.Clamp(damageAmt, 0, int.MaxValue);

        m_currHealth -= damageAmt;

        Debug.Log(transform.name + " takes " + damageAmt + " damage");

        if (m_currHealth <= 0)
        {
            m_currHealth = Mathf.Clamp(m_currHealth, 0, m_maxHealth);

            StartCoroutine(Die());
        }
    }

    public void RestoreHealth(int healAmount)
    {
        m_currHealth += healAmount;

        if (m_currHealth > m_maxHealth)
        {
            m_currHealth = m_maxHealth;
        }
    }

    public virtual IEnumerator Die()
    {
        // Play character's death animations, and respawn, etc....

        yield return new WaitForSeconds(0.001f);
        Debug.Log(transform.name + " has died. ");
    }
}
