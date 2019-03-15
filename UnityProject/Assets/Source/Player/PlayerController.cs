using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float movement_speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        ResourceManager rm = Singleton.GetResourceManager ( );

        player.EquipWeapon ( rm.LoadAsset < Weapon > ( "WeaponData/Pistol" ) );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move_direction = new Vector3 ( Input.GetAxis ( "Horizontal" ), 0.0f, Input.GetAxis ( "Vertical" ) );

        move_direction *= movement_speed;

        move_direction = transform.TransformDirection ( move_direction );

        rigidbody.MovePosition ( transform.position + ( move_direction * Time.deltaTime ) );
    }
}
