using System.Collections;
using UnityEngine;

[CreateAssetMenu ( fileName = "weapon", menuName = "Inventory/Weapon", order = 1 )]
public class Weapon : ScriptableObject
{
    public int id = 0;
    public Mesh mesh = null;
    public int damage = 0;
    public int fire_rate = 1;
}
