using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifetime = 0.4f;

    [SerializeField]
    private float projectile_speed = 200.0f;

    private float spawn_time;

    private float damage;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start ( )
    {
        rigidbody = gameObject.GetComponent < Rigidbody > ( );
    }

    void Update ( )
    {
        if ( ( Time.time - spawn_time ) >= lifetime )
        {
            gameObject.SetActive ( false );
        }
    }

    // Update is called once per frame
    void FixedUpdate ( )
    {
        rigidbody.MovePosition ( transform.position + ( transform.forward * projectile_speed * Time.deltaTime) );
    }

    void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.tag == "Enemy" )
        {
            Debug.Log ( "Hit Object" );
            other.gameObject.GetComponent < Enemy > ( ).DeductHealth ( damage );
            gameObject.SetActive ( false );
        }
    }

    public void SetSpawnTime ( float time )
    {
        spawn_time = time;
    }

    public void SetDamage ( float amount )
    {
        damage = amount;
    }
}
