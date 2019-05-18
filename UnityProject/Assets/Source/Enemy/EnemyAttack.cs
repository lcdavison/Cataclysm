using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private AudioSource gun_sound;

    private Enemy enemy_script;

    private Player player;

    private float last_time = 0.0f;

    //  Awake is called before start function
    void Awake ( )
    {
        //  Get the enemy script attached to the parent of this game object
        enemy_script = gameObject.transform.parent.gameObject.GetComponent < Enemy > ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        //  Check if the player is available
        if ( player != null )
        {
            float current_time = Time.time;

            //  Calculate direction to player
            Vector3 direction = enemy_script.player_transform.position - transform.position;

            //  If time period has passed and player is in front of the enemy, shoot at the player
            if ( current_time - last_time >= 1.0f && Vector3.Dot ( direction, transform.forward ) > 0.0f )
            {
                Shoot ( );
                last_time = current_time;
            }
        }
    }

    //  Check for game objects entering the trigger
    void OnTriggerEnter ( Collider other )
    {
        //  Check the other game object is the player
        if ( other.gameObject.tag == "Player" )
        {
            //  Get the player script and update the enemy's reference to the player position
            player = other.gameObject.GetComponent < Player > ( );
            enemy_script.player_transform = other.gameObject.transform;
        }
    }

    //  Check for game objects exiting the trigger
    void OnTriggerExit ( Collider other )
    {
        //  Check if the other game object is the player
        if ( other.gameObject.tag == "Player" )
        {
            //  Null player references
            player = null;
            enemy_script.player_transform = null;
        }
    }

    //  Fire at the player
    private void Shoot (  )
    {
        gun_sound.Play ( );

        RaycastHit hit;
        if ( Physics.Raycast ( transform.position, transform.forward, out hit, 30.0f ) )
        {
            //  If the raycast hit the player, deduct health
            if ( hit.collider.gameObject.tag == "Player" )
                player.DeductHealth ( 5.0f );
        }
    }
}
