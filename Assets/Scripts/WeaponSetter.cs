using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour
{
    //cache
    List<GameObject> weapons = new List<GameObject>();
    static string activeWeapon;

    void Start()
    {
        BuildWeaponsList();
        WeaponDeactivator();
        WeaponSetterMethod(1); //equip barehand
    }

    void Update()
    {
        WeaponSelector();
    }

    private void BuildWeaponsList()
    {
        foreach (Transform transformOfChild in gameObject.transform) //accessing childrens' transforms
        {
            weapons.Add(transformOfChild.gameObject);
        }
    }

    //TODO: Avoid string references!!!! (Work on this)
    private void WeaponSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            WeaponSetterMethod(1);
            SetActiveWeapon("Bare Hand");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        { 
            WeaponSetterMethod(2);
            SetActiveWeapon("Pistol");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            WeaponSetterMethod(3);
            SetActiveWeapon("Sword");
        }
    }

    private void SetActiveWeapon(string weaponName)
    {
        activeWeapon = weaponName;
    }

    public static string GetActiveWeapon()
    {
        return activeWeapon;
    }

    private void WeaponDeactivator()
    {
        foreach (Transform transformOfChild in gameObject.transform) //accessing childrens' transforms
        {
            transformOfChild.gameObject.SetActive(false);
        }
    }

    private void WeaponSetterMethod(int weaponIndex)
    {
        WeaponDeactivator();
        weapons[weaponIndex - 1].SetActive(true);
    }
}
