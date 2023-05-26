using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _shootingDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _stopShootingDistance;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private bool _autoShoot = true;

    private bool _isShooting = false;
    private Coroutine _shooting;
    private Health _currentTarget;
    private Health _selfHealth;

    private void Start()
    {
        _selfHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BulletBonus bulletBonus))
        {
            _weapon.AddBullets(bulletBonus.Count);
            bulletBonus.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), _shootingDistance, _layerMask);


        if (collider != null && _isShooting == false)
        {

            if (collider.gameObject.TryGetComponent(out Health health))
            {
                if (health.IsDead == false && health.gameObject != gameObject && _shooting == null)
                {
                    _currentTarget = health;
                    if (_autoShoot)
                    {
                        Shoot(health);
                        return;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            ShootOneTime();
                        }
                    }
                }
            }
        }

    }
    public void ShootOneTime()
    {
        if (_currentTarget != null)
        {
            _weapon.Shoot(_currentTarget.transform.position);
        }

    }
    private void Shoot(Health target)
    {
        if (_shooting == null)
        {
            _isShooting = true;
            _shooting = StartCoroutine(Shooting(target));
        }
    }

    private void StopShoot()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
            _isShooting = false;
            _shooting = null;
            _currentTarget = null;
        }
    }

    private IEnumerator Shooting(Health target)
    {
        while (_selfHealth.IsDead == false && _currentTarget != null
            && target.IsDead == false && Vector3.Distance(_currentTarget.transform.position, transform.position) < _stopShootingDistance)
        {
            _weapon.Shoot(_currentTarget.transform.position);
            yield return null;
            yield return new WaitForSeconds(_timeBetweenShoot);
        }
        _isShooting = false;
        _shooting = null;
        _currentTarget = null;
    }
}
