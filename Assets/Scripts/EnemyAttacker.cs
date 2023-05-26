using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Coroutine _attacking;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth)&&_attacking==null)
        {
            _attacking = StartCoroutine(Attacking(playerHealth));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            StopCoroutine(_attacking);
            _attacking = null;
        }
    }

    private IEnumerator Attacking(PlayerHealth playerHealth)
    {
        while (true)
        {
            playerHealth.TakeDamage(_damage);
            yield return new WaitForSeconds(1);
            yield return null;
        }
    }
}
