using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon_obj;

    [SerializeField]
    private Weapon equipped_weapon;

    public void EquipWeapon ( Weapon weapon )
    {
        MeshFilter weapon_mesh = weapon_obj.GetComponent < MeshFilter > ( );
        equipped_weapon = weapon;
        weapon_mesh.mesh = equipped_weapon.weapon_mesh;
    }
}
