using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MouseRotator : MonoBehaviour
{
    void Update()
    {
        FaceMouse(GetMouseDirectionVector());
    }

    public Vector2 GetMouseDirectionVector()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2
            (mousePos.x - transform.position.x,
             mousePos.y - transform.position.y).normalized; //normalized gives unit vector.
        return direction;

    }

    private void FaceMouse(Vector2 direction)
    {
        transform.up = direction; //makes it "look in" the given direction
    }
}
