using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private AudioSource gun_sound;

    private float max_health = 100.0f;
    private float health;

    private float last_time = 0.0f;

    private Enemy closest_enemy;

    void Awake ( )
    {
        health = max_health;
    }

    void Update ( )
    {
        if ( health <= 0.0f )
        {
            //  Load Death Scene
            SceneManager.LoadScene ( "Death" );
        }
    }

    void FixedUpdate ( )
    {
        RaycastHit hit;
        if ( Physics.Raycast ( weapon_offset.transform.position, transform.forward, out hit, Mathf.Infinity, 1 ) )
        {
            if ( hit.collider.gameObject.tag == "Enemy" )
            {
                Debug.DrawRay ( weapon_offset.transform.position, transform.forward * hit.distance, Color.blue );
                closest_enemy = hit.collider.gameObject.GetComponent < Enemy > ( );
            }
            else
            {
                closest_enemy = null;
            }
        }

        health_bar.value = health / max_health;
    }

    public void DeductHealth ( float amount )
    {
        health -= amount;
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
        else
        {
            explosion.Stop ( );
        }
    }

    public Enemy GetClosestEnemy ( )
    {
        return closest_enemy;
    }

    private void SpawnBullet ( )
    {
        if ( explosion.isStopped )
            explosion.Play ( );

        gun_sound.Play ( );

        RaycastHit hit;
        Debug.DrawRay ( transform.position, Camera.main.transform.forward * 60.0f, Color.red );
        if ( Physics.Raycast ( transform.position, Camera.main.transform.forward, out hit, 60.0f ) )
        {
            if ( hit.collider.gameObject.tag == "Enemy" )
            {
                Enemy hit_enemy = hit.collider.gameObject.GetComponent < Enemy > ( );
                hit_enemy.DeductHealth ( equipped_weapon.damage );
            }
        }
    }
}
