using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;

    protected bool _isDead = false;

    protected int _currentHealth;
    protected Animator _animator;

    public bool IsDead => _isDead;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hier");

        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet.Damage);
            bullet.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int count)
    {
        _currentHealth -= count;
        float currentHealthByMaxHealth = (float)_currentHealth / _maxHealth;
        HealthChanged?.Invoke(currentHealthByMaxHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
            _isDead = true;
        }
    }

    public void Heal(int count)
    {
        _currentHealth += count;
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        float currentHealthByMaxHealth = (float)_currentHealth / _maxHealth;
        HealthChanged?.Invoke(currentHealthByMaxHealth);
    }

    public void SetNoDie()
    {
        _isDead = false;
        Heal(_maxHealth);
    }

    public abstract void Die();
}
