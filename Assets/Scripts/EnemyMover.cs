using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _viewingDistance;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;

    private Coroutine _searching;
    private Coroutine _moving;
    private bool _needSearch = true;
    private bool _needMove = true;

    private void Update()
    {
        if (_searching == null)
        {
            _searching = StartCoroutine(Searching());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _needMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _needMove = true;
        }
    }
    private IEnumerator Searching()
    {
        while (true)
        {
            Search();
            yield return new WaitForSeconds(1);
            yield return null;
        }
    }
    private void Search()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), _viewingDistance, _layerMask);
        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out PlayerMover mover))
                {
                    if (_needMove)
                    {
                        MoveTo(mover);
                        return;
                    }
                }
            }
        }
    }

    private void MoveTo(PlayerMover target)
    {
        if (_moving == null)
        {
            _moving = StartCoroutine(MovingTo(target));

        }
    }

    private IEnumerator MovingTo(PlayerMover target)
    {
        while (_needMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
        _moving = null;
    }
}
