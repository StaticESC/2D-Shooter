using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    //Serialize Fields
    [SerializeField] GameObject bullet;
    [SerializeField] int timeToDestroyBullet = 3;

    //declarations and cache
    Animator myAnimator;  //prolly make this a serialize field too.
    GameObject shoulderParent;


    private void Start()
    {
        shoulderParent = transform.parent.parent.gameObject;
        myAnimator = shoulderParent.GetComponent<Animator>();
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
            GameObject bulletInstantiation = Instantiate(bullet, transform.position, shoulderParent.transform.rotation);
            Destroy(bulletInstantiation, timeToDestroyBullet);
        }
       
    }
}
