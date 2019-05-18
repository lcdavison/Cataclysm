using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon_obj;  //  The weapon placeholder

    [SerializeField]
    private Transform weapon_offset;    //  Location of weapon barrell

    [SerializeField]
    private Slider health_bar;  //  Health bar

    [SerializeField]
    private Weapon equipped_weapon; //  Data of equipped weapon

    [SerializeField]
    private ParticleSystem explosion;   //  Particle effect for explosion

    [SerializeField]
    private AudioSource gun_sound;  //  Gun sound source

    [SerializeField]
    private AudioSource oof_sound;  //  Player damaged sound source

    private float health;   //  Current health value

    private float last_time = 0.0f;

    private Enemy closest_enemy;    //  Closest enemy to display info for

    //  Awake is called before start function
    void Awake ( )
    {
        ResourceManager rm = Singleton.GetResourceManager ( );
        rm.CacheWeapons ( );

        health = 100.0f;

        //  Set the current equipped weapon
        EquipWeapon ( rm.GetWeapon ( 0 ) );
    }

    //  Update is called once per frame
    void Update ( )
    {
        FireWeapon ( );

        //  If health drops below 0, player dies
        if ( health <= 0.0f )
        {
            //  Unlock the cursor
            Cursor.lockState = CursorLockMode.None;

            //  Load Death Scene
            SceneManager.LoadScene ( "Death" );
        }
    }

    //  FixedUpdate is called for physics updates
    void FixedUpdate ( )
    {
        //  Use raycast to detect enemy in front of the player
        RaycastHit hit;
        if ( Physics.Raycast ( weapon_offset.position, transform.forward, out hit, Mathf.Infinity, 1 ) )
        {
            if ( hit.collider.gameObject.tag == "Enemy" )
            {
                //  Set as closest enemy
                closest_enemy = hit.collider.gameObject.GetComponent < Enemy > ( );
            }
            else
            {
                //  No enemy in front of player
                closest_enemy = null;
            }
        }

        //  Update health bar value
        health_bar.value = health / 100.0f;
    }

    //  Deduct amount of health
    public void DeductHealth ( float amount )
    {
        oof_sound.Play ( );
        health -= amount;
    }

    //  Equip a weapon on the player
    public void EquipWeapon ( Weapon weapon )
    {
        MeshFilter weapon_mesh = weapon_obj.GetComponent < MeshFilter > ( );
        equipped_weapon = weapon;

        //  Update game object mesh and offset position
        weapon_mesh.mesh = equipped_weapon.mesh;
    }

    //  Shoots players weapon
    public void FireWeapon ( )
    {
        //  If player clicks left mouse button shoot
        if ( Input.GetKey ( KeyCode.Mouse0 ) )
        {
            float current_time = Time.time;

            //  If time between bullets firing has passed, fire another bullet
            if ( current_time - last_time >= ( 1.0f / equipped_weapon.fire_rate ) )
            {
                last_time = current_time;

                Shoot ( );
            }
        }
        else
        {
            //  Stop the particle effect
            explosion.Stop ( );
        }
    }

    //  Get the enemy in front of the player
    public Enemy GetClosestEnemy ( )
    {
        return closest_enemy;
    }

    //  Shoot a bullet from the players gun
    private void Shoot ( )
    {
        //  Play the barrell particle effect, when it has stopped
        if ( explosion.isStopped )
            explosion.Play ( );

        //  Play the gun sound effect
        gun_sound.Play ( );

        //  Fire a ray from the
        RaycastHit hit;
        if ( Physics.Raycast ( weapon_offset.position, Camera.main.transform.forward, out hit, 60.0f ) )
        {
            //  Check the ray hits an enemy
            if ( hit.collider.gameObject.tag == "Enemy" )
            {
                //  Damage the enemy
                Enemy hit_enemy = hit.collider.gameObject.GetComponent < Enemy > ( );
                hit_enemy.DeductHealth ( equipped_weapon.damage );
            }
        }
    }
}
