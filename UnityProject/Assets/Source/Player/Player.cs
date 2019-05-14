using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon_obj;

    [SerializeField]
    private GameObject weapon_offset;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Slider health_bar;

    [SerializeField]
    private Weapon equipped_weapon;

    private BulletPool bullet_pool;

    private float max_health = 100.0f;
    private float health;

    private float last_time = 0.0f;

    private Enemy closest_enemy;

    void Awake ( )
    {
        bullet_pool = new BulletPool ( projectile, 30 );
        health = max_health;
    }

    void Update ( )
    {
        RaycastHit hit;
        if ( Physics.Raycast ( transform.position, transform.forward, out hit, Mathf.Infinity, 1 ) )
        {
            if ( hit.collider.gameObject.tag == "Enemy" )
            {
                Debug.DrawRay ( transform.position, transform.forward * hit.distance, Color.blue );
                closest_enemy = hit.collider.gameObject.GetComponent < Enemy > ( );
            }
            else
            {
                closest_enemy = null;
            }
        }

        health_bar.value = health / max_health;
    }

    public void EquipWeapon ( Weapon weapon )
    {
        MeshFilter weapon_mesh = weapon_obj.GetComponent < MeshFilter > ( );
        equipped_weapon = weapon;
        weapon_mesh.mesh = equipped_weapon.mesh;
        weapon_offset.transform.localPosition = weapon.offset;
    }

    public void FireWeapon ( )
    {
        if ( Input.GetKey ( KeyCode.Mouse0 ) )
        {
            float current_time = Time.time;
            if ( current_time - last_time >= ( 1.0f / equipped_weapon.fire_rate ) )
            {
                last_time = current_time;

                SpawnBullet ( );
            }
        }
    }

    public Enemy GetClosestEnemy ( )
    {
        return closest_enemy;
    }

    private void SpawnBullet ( )
    {
        GameObject bullet = bullet_pool.GetBullet ( );

        bullet.transform.position = weapon_offset.transform.position;
        bullet.transform.rotation = weapon_offset.transform.rotation;

        Projectile p = bullet.GetComponent < Projectile > ( );
        p.SetSpawnTime ( Time.time );
        p.SetDamage ( equipped_weapon.damage );

        bullet.SetActive ( true );
    }
}
