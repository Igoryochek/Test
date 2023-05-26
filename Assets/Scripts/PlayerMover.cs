using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, _speed);
    }
}
