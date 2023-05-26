using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletButton : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TextMeshProUGUI _countText;
    private void OnEnable()
    {
        ShowCount();
        _weapon.BulletsCountChanged += ShowCount;
    }
    private void OnDisable()
    {
        _weapon.BulletsCountChanged -= ShowCount;
    }

    public void ShowCount(int count)
    {
        _countText.text = count.ToString();
    }
    public void ShowCount()
    {
        _countText.text = _weapon.BulletsCount.ToString();
    }
}
