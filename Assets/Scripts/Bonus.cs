using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private int _count;

    public int Count=>_count;
}
