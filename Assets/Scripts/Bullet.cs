using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public void MoveTo(Vector3 target)
    {
        StartCoroutine(MovingTo(target));
    }

    private IEnumerator MovingTo(Vector3 target)
    {
        Vector3 newPosition = target;
        while (transform.position.x != newPosition.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPosition.x, newPosition.y, 0), _speed * Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
