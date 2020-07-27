using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour
{
    //cache
    List<GameObject> weapons = new List<GameObject>();


    //to be set by a setter method


    void Start()
    {
        BuildWeaponsList();
        WeaponDeactivator();
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

    private void WeaponSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { WeaponSetterMethod(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { WeaponSetterMethod(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { WeaponSetterMethod(3); }
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
