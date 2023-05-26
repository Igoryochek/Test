using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private int _bulletsCount = 30;

    public int BulletsCount => _bulletsCount;

    public event UnityAction<int> BulletsCountChanged;
    public void Shoot(Vector3 target)
    {
        if (_bulletsCount > 0)
        {
            _bulletsCount--;
            BulletsCountChanged?.Invoke(_bulletsCount);
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);
            bullet.MoveTo(target);
        }
    }

    public void AddBullets(int count)
    {
        _bulletsCount += count;
        BulletsCountChanged?.Invoke(_bulletsCount);
    }

    public void RemoveBullets(int count)
    {
        _bulletsCount -= count;
        BulletsCountChanged?.Invoke(_bulletsCount);
    }
}
