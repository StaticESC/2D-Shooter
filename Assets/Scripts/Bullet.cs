using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //serialize fields
    [SerializeField] float bulletVelocity;
    [SerializeField] float damage;
    
    //declarations and cache
    Rigidbody2D myRigidbody;
    MouseRotator mouseRotatorObject;
    Health health;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mouseRotatorObject = FindObjectOfType<MouseRotator>();
        health = FindObjectOfType<Health>();

        var mouseRotator = mouseRotatorObject.GetComponent<MouseRotator>();
        var direction =  mouseRotator.GetMouseDirectionVector();
            
        myRigidbody.velocity = direction * bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.tag == "Enemy") //all enemy objects have a health script
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth(damage);
        }

    }


}
