using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject _restartPanel;
    public override void Die()
    {
        _restartPanel.SetActive(true);
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}
