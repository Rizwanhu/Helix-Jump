using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float angle;  // Optional: Set the rotation speed multiplier
    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X");
        //{
        //    // Rotate the first child object around the Y-axis, scale by angle and mouse movement
        //    transform.GetChild(0).transform.Rotate(
        //        transform.position, // The point of rotation
        //        Vector3.up, // Rotate around the Y-axis
        //        x * angle // Rotation speed, scaled by mouse input
        //    );
        //}
        transform.GetChild(0).Rotate(Vector3.up,-1* x * angle, Space.World);

        //transform.GetChild(0).transform.RotateAround(transform.position, new Vector3(0, 1, 0)*Time.deltaTime*-1* x , angle);

        // check for rotation of background collider do it also rortate ? etc
    }
}
