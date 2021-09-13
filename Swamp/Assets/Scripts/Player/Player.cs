using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))] 
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<GameObject> _armory;
    [SerializeField] private Transform _handPoint;

    private float _currentHealth;
    private int _currentWeaponIndex = 0;
    private GameObject _createdWeapon;

    private void Start()
    {
        _currentHealth = _health;
        SetWeapon(0);
    }

    private void Update()
    {
        CheckHealth();
    }

    private void SetWeapon(int index)
    {
        _currentWeaponIndex = index;
        Destroy(_createdWeapon);
        _createdWeapon = Instantiate(_armory[_currentWeaponIndex], _handPoint.position, Quaternion.identity);
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
