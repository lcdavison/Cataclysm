using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy/New Enemy", fileName = "new_enemy")]
public class EnemyData : ScriptableObject
{
    public string name = "Bandito";
    public int level = 0;
    public int health = 50;
}
