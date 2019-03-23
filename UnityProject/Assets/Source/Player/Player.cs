using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon_obj;

    [SerializeField]
    private Weapon equipped_weapon;

    [SerializeField]
    private GameObject weapon_offset;

    [SerializeField]
    private GameObject projectile;

    private float last_time = 0.0f;

    public void EquipWeapon ( Weapon weapon )
    {
        MeshFilter weapon_mesh = weapon_obj.GetComponent < MeshFilter > ( );
        equipped_weapon = weapon;
        weapon_mesh.mesh = equipped_weapon.weapon_mesh;
    }

    public void FireWeapon ( )
    {
        if ( equipped_weapon.automatic )
        {
            if ( Input.GetKey ( KeyCode.Mouse0 ) )
            {
                if ( Time.time - last_time > ( 1 / equipped_weapon.fire_rate ) )
                {
                    Debug.Log ( "Auto Fire" );
                    last_time = Time.time;
                    GameObject.Instantiate ( projectile, weapon_offset.transform.position, transform.rotation );
                }
            }
        }
        else
        {
            if ( Input.GetKeyDown ( KeyCode.Mouse0 ) )
                GameObject.Instantiate ( projectile, weapon_offset.transform.position, transform.rotation );
        }
    }
}
