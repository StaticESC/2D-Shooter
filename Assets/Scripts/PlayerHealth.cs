using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(player.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Dead");
        player.health -= 100;
    }
}
