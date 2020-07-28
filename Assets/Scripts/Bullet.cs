using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //serialize fields
    [SerializeField] float bulletVelocityX;
    
    
    //declarations and cache
    Rigidbody2D myRigidbody;
    MouseRotator mouseRotatorObject;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mouseRotatorObject = FindObjectOfType<MouseRotator>();

        var mouseRotator = mouseRotatorObject.GetComponent<MouseRotator>();
        var direction =  mouseRotator.GetMouseDirectionVector();
            
        myRigidbody.velocity = direction * bulletVelocityX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


}
