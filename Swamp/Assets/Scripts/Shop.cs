using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        foreach (Weapon weapon in _weapons)
        AddItem(weapon);
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.Render(weapon);
        view.BuyButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView view)
    {
        var wallet = _player.GetComponent<Wallet>();

        if (wallet == null)
            return;

        if (wallet.CheckMoney() >= weapon.WeaponInfo.Price)
        {
            _player.BuyWeapon(weapon);
            wallet.AddMoney(-1*weapon.WeaponInfo.Price);
        }

        view.BuyButtonClick -= OnSellButtonClick;
    }
}
