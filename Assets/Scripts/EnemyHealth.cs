using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject _bonusPrefab;
    public override void Die()
    {
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(1);
        int randomChance = Random.Range(1, 10);
        if (randomChance>1)
        {
            Instantiate(_bonusPrefab);
        }
        gameObject.SetActive(false);
    }
}
