using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Wallet))] 
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<GameObject> _armory;
    [SerializeField] private Transform _handPoint;

    private float _currentHealth;
    private int _currentWeaponIndex = 0;
    private float _currentTime = 0;
    private float _timeForDeathAnimation = 2;
    private GameObject _currentWeapon;

    public UnityAction<float, float> HealthChanged;

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
        if (index >= _armory.Count)
            index = 0;

        var weapon = _armory[index].GetComponent<Weapon>();

        if (weapon == null)
            return;
            
        if (!weapon.IsBought)
            return;

        Destroy(_currentWeapon);
        _currentWeaponIndex = index;
        _currentWeapon = Instantiate(_armory[_currentWeaponIndex], _handPoint.position, Quaternion.identity);
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        TryGetComponent(out Animator animator);

        if (_currentTime == 0)
            animator.Play("Death");
        
            _currentTime += Time.deltaTime;

        if (_timeForDeathAnimation <= _currentTime)
            Destroy(gameObject);

        Destroy(_currentWeapon);
    }

    public void ChangeWeapon()
    {
        ++_currentWeaponIndex;
        SetWeapon(_currentWeaponIndex);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_health, _currentHealth);
    }

    public void BuyWeapon(Weapon weapon)
    {
        foreach(GameObject item in _armory)
        {
            item.TryGetComponent(out Weapon weap);

            if (weap.WeaponInfo.Name==weapon.WeaponInfo.Name)
                weap.SetBought(true);
        } 
    }
}
