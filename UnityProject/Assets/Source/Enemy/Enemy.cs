using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player_transform;

    [SerializeField]
    private EnemyData data;

    private float health;

    // Start is called before the first frame update
    void Start ( )
    {
        health = data.health;
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( player_transform != null )
        {
            //  Rotate the enemy towards the player
            Vector3 look_direction = Vector3.RotateTowards ( transform.forward, player_transform.position - transform.position, 2.0f * Time.deltaTime, 0.0f );

            transform.rotation = Quaternion.LookRotation ( look_direction );
        }

        if ( health <= 0.0f )
        {
            GameObject.Destroy ( gameObject );
        }
    }

    public void DeductHealth ( float amount )
    {
        health -= amount;
    }

    public float GetHealth ( )
    {
        return health;
    }

    public EnemyData GetData ( )
    {
        return data;
    }
}
