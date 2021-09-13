using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _bulletAmount;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private Transform _pointOfFire;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private UnityEvent Shooted;

    private int _currentBulletAmount;
    protected bool _reloaded;
    private float _currentTime=0;

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
                Bullet clone = Instantiate(_bulletTemplate, _pointOfFire.transform.position, Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right.normalized * Time.deltaTime * _bulletSpeed, ForceMode2D.Impulse);
                _currentBulletAmount--;
            }
    }

    private void Reload()
    {
        if (_currentTime >= _reloadTime)
        {
            _currentTime = 0;
            _currentBulletAmount++;
        }
    }

    private void CheckWeaponState()
    {
        if (_currentBulletAmount == 0) _reloaded = false;

        if (_currentBulletAmount == _bulletAmount) _reloaded = true;

        if(_reloaded == false)
            Reload();

        if (Input.GetMouseButton(0)&&_reloaded)
            Shoot();
    }


}
