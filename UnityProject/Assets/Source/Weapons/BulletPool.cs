using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List < GameObject > pool = new List < GameObject > ( );

    private const byte BULLET_POOL_SIZE = 100;

    public BulletPool ( GameObject projectile, int pool_size )
    {
        projectile.SetActive ( false );

        for ( int i = 0; i < pool_size; ++i )
            pool.Add ( GameObject.Instantiate ( projectile, Vector3.zero, Quaternion.identity ) );
    }

    public GameObject GetBullet ( )
    {
        GameObject bullet = null;

        for ( int i = 0; i < pool.Count; ++i )
        {
            if ( !pool [ i ].activeInHierarchy )
            {
                bullet = pool [ i ];
            }
        }

        return bullet;
    }

    public int GetSize ( )
    {
        return pool.Count;
    }
}
