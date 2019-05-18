using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player_transform;

    [SerializeField]
    private EnemyData data;

    [SerializeField]
    private AudioSource audio_source;

    [SerializeField]
    private AudioClip death;

    private float health;

    // Start is called before the first frame update
    void Start ( )
    {
        health = data.health;
    }

    // Update is called once per frame
    void Update ( )
    {
        //  If the player is in range look at them
        if ( player_transform != null )
        {
            //  Rotate the enemy towards the player
            Vector3 look_direction = Vector3.RotateTowards ( transform.forward, player_transform.position - transform.position, Time.deltaTime, 0.0f );
            transform.rotation = Quaternion.LookRotation ( look_direction );
        }

        //  If lost all health destroy enemy
        if ( health <= 0.0f )
        {
            //  Play death sound if not currently playing
            if ( !audio_source.isPlaying )
            {
                audio_source.volume = 0.75f;
                audio_source.PlayOneShot ( death );
            }

            //  Destroy game object after sound has played
            GameObject.Destroy ( gameObject, death.length );
        }
    }

    //  Reduce health by a certain amount
    public void DeductHealth ( float amount )
    {
        health -= amount;
    }

    //  Get enemy health
    public float GetHealth ( )
    {
        return health;
    }

    //  Get enemy data
    public EnemyData GetData ( )
    {
        return data;
    }
}
