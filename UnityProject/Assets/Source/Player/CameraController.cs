using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 rotation;   //  Stores the cameras rotation

    [SerializeField]
    private Vector2 mouse_sensitivity = new Vector2 ( 1.0f, 1.0f ); //  Used to control mouse movement speed

    // Update is called once per frame
    void LateUpdate ( )
    {
        //  Add movement axes to rotation
        rotation.x += Input.GetAxisRaw ( "Mouse X" ) * mouse_sensitivity.x;
        rotation.y += Input.GetAxisRaw ( "Mouse Y" ) * mouse_sensitivity.y;

        //  Clamp up and down look angle by -60 and 60 degrees
        rotation.y = Mathf.Clamp ( rotation.y, -60.0f, 60.0f );

        //  Rotate the camera and the player
        transform.localRotation = Quaternion.Euler ( rotation.y * -1.0f, 0.0f, 0.0f );
        transform.parent.rotation = Quaternion.Euler ( 0.0f, rotation.x, 0.0f );
    }
}
