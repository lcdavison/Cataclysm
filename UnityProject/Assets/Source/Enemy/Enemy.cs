using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform marker;

    public Transform target;

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
