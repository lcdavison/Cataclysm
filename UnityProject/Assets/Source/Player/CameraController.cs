using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 rotation;

    [SerializeField]
    private Vector2 mouse_sensitivity = new Vector2 ( 1.0f, 1.0f );
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotation.x += Input.GetAxisRaw ( "Mouse X" ) * mouse_sensitivity.x;
        rotation.y += Input.GetAxisRaw ( "Mouse Y" ) * mouse_sensitivity.y;

        rotation.y = Mathf.Clamp ( rotation.y, -60.0f, 60.0f );

        transform.rotation = Quaternion.Euler ( rotation.y * -1.0f, rotation.x, 0.0f );
        transform.parent.rotation = Quaternion.Euler ( 0.0f, rotation.x, 0.0f );
    }
}
