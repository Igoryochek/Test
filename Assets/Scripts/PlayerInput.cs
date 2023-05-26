using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;

    private PlayerMover _mover;
    private bool _isMobile = true;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }
    private void Update()
    {
        if (_isMobile)
        {
            Vector3 newDirection = new Vector3(transform.position.x + _joystick.Horizontal,
                 transform.position.y + _joystick.Vertical, transform.position.z);
            if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
            {
                _mover.Move(newDirection);
            }
        }
    }
}
