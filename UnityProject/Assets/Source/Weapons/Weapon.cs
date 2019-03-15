using System.Collections;
using UnityEngine;

[CreateAssetMenu ( fileName = "weapon", menuName = "Inventory/Weapon", order = 1 )]
public class Weapon : ScriptableObject
{
    public int weapon_id = 0;
    public Mesh weapon_mesh = null;
    public int damage = 0;
    public bool automatic = false;
}
