using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _bulletAmount;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private Transform _pointOfFire;
    [SerializeField] private UnityEvent Shooted;
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private bool _isBought;

    private int _currentBulletAmount;
    private bool _reloaded;
    private float _currentTime=0;

    public UnityAction<int, int> BulletAmountChanged;

    public WeaponInfo WeaponInfo => _weaponInfo;
    public bool IsBought => _isBought;

    private void Start()
    {
        _currentBulletAmount = _bulletAmount;
        _reloaded = true;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        CheckWeaponState();
    }

    public void Shoot()
    {
        if (_currentTime >= _rateOfFire)
        {
            _currentTime = 0;
            Bullet clone = Instantiate(_weaponInfo.BulletTemplate, _pointOfFire.transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right.normalized * Time.deltaTime * _bulletSpeed, ForceMode2D.Impulse);
            _currentBulletAmount--;
            BulletAmountChanged?.Invoke(_bulletAmount, _currentBulletAmount);
        }
    }

    private void Reload()
    {
        if (_currentTime >= _reloadTime)
        {
            _currentTime = 0;
            _currentBulletAmount++;
            BulletAmountChanged?.Invoke(_bulletAmount, _currentBulletAmount);
        }
    }

    private void CheckWeaponState()
    {
        if (_currentBulletAmount == 0)
            _reloaded = false;

        if (_currentBulletAmount == _bulletAmount)
            _reloaded = true;

        if(_reloaded == false)
            Reload();

        if (Input.GetMouseButton(0)&&_reloaded)
            Shoot();
    }

    public void SetBought(bool set)
    {
        _isBought = set;
    }

}
