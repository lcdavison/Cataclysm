using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 1.0f;

    [SerializeField]
    private float projectile_speed = 200.0f;

    private float death_time;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent < Rigidbody > ( );
        death_time = Time.time + lifetime;
    }

    void Update ( )
    {
        if ( Time.time >= death_time )
            GameObject.Destroy ( gameObject );
    }

    // Update is called once per frame
    void FixedUpdate ( )
    {
        rigidbody.MovePosition ( transform.position + ( transform.forward * projectile_speed * Time.deltaTime) );
    }
}
