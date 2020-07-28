using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    Animator myAnimator;

    private void Start()
    {
        myAnimator = gameObject.transform.parent.parent.gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        PistolShoot();
    }

    private void PistolShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponSetter.GetActiveWeapon() == "Pistol")
        {
            myAnimator.SetTrigger("PistolShoot");
        }
    }
}
