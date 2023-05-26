using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private PlayerUnit _player;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _player.transform.position+_offset;
    }
}
