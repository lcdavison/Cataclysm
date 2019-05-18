using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller; //  Character controller attached to player

    [SerializeField]
    private float movement_speed = 2.0f;    //  Speed to move the player at

    private Player player;
    private ResourceManager rm;

    // Start is called before the first frame update
    void Start ( )
    {
        //  Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        rm = Singleton.GetResourceManager ( );

        player = gameObject.GetComponent < Player > ( );
    }

    //  Update is called once per frame
    void Update ( )
    {
        //  Equip weapon when a number key is pressed
        if ( Input.GetKeyDown ( KeyCode.Alpha1 ) )
        {
            player.EquipWeapon ( rm.GetWeapon ( 0 ) );
        }
        else if ( Input.GetKeyDown ( KeyCode.Alpha2 ) )
        {
            player.EquipWeapon ( rm.GetWeapon ( 1 ) );
        }
    }

    // FixedUpdate is called once per frame to update physics
    void FixedUpdate ( )
    {
        Vector3 move_direction = new Vector3 ( Input.GetAxisRaw ( "Horizontal" ), 0.0f, Input.GetAxisRaw ( "Vertical" ) );

        //  Sprint if the shift key is held down
        if ( Input.GetKey ( KeyCode.LeftShift ) )
            move_direction *= ( movement_speed * 2 );
        else
            move_direction *= movement_speed;

        //  Transform direction into world space
        move_direction = transform.TransformDirection ( move_direction );

        //  Introduce gravity
        move_direction.y = -2.0f;

        //  Move character in direction
        controller.Move ( move_direction * Time.deltaTime );
    }
}
