using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy_script;

    private Player player;

    private float last_time = 0.0f;

    void Awake ( )
    {
        enemy_script = gameObject.transform.parent.gameObject.GetComponent < Enemy > ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( player != null )
        {
            float current_time = Time.time;

            Vector3 direction = player.gameObject.transform.position - transform.position;

            if ( current_time - last_time >= 1.0f )
            {
                Shoot ( direction );
                last_time = current_time;
            }
        }
    }

    void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            player = other.gameObject.GetComponent < Player > ( );
            enemy_script.player_transform = other.gameObject.transform;
        }
    }

    void OnTriggerExit ( Collider other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            player = null;
            enemy_script.player_transform = null;
        }
    }

    private void Shoot ( Vector3 direction )
    {
        RaycastHit hit;
        if ( Physics.Raycast ( transform.position, direction.normalized, out hit, direction.magnitude ) )
        {
            player.DeductHealth ( 5.0f );
        }
    }
}
