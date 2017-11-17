using UnityEngine;
using System.Collections;

[System.Serializable]
/*
 * Generic properties for a character's stats
 */
public class CharacterStats : MonoBehaviour
{
    protected int _maxHealth;

    [SerializeField]
    protected int _currHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return _currHealth; }
        private set { _currHealth = value; }
    }
    

    public void Awake()
    {
        _currHealth = _maxHealth;
    }

    public void InitializeHealth(int max)
    {
        _maxHealth = max;
        _currHealth = _maxHealth;
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

        _currHealth -= damageAmt;


        if (_currHealth <= 0)
        {
            _currHealth = Mathf.Clamp(_currHealth, 0, _maxHealth);

            StartCoroutine(Die());
        }
    }

    public void RestoreHealth(int healAmount)
    {
        _currHealth += healAmount;

        if (_currHealth > _maxHealth)
        {
            _currHealth = _maxHealth;
        }
    }

    public virtual IEnumerator Die()
    {
        // Play character's death animations, and respawn, etc....

        yield return new WaitForSeconds(0.001f);
    }
}
