using System.Collections;
using UnityEngine;

[CreateAssetMenu ( fileName = "weapon", menuName = "Inventory/Weapon", order = 1 )]
public class Weapon : ScriptableObject
{
    public int id = 0;
    public Mesh mesh = null;
    public Vector3 offset = Vector3.zero;
    public int damage = 0;
    public bool automatic = false;
    public int fire_rate = 1;
}
