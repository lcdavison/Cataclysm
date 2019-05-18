using System;
using System.Collections;
using UnityEngine;

public class ResourceManager
{
    private Weapon [] weapons;

    //  Cache all the weapon data
    public void CacheWeapons ( )
    {
        weapons = Array.ConvertAll ( Resources.LoadAll ( "WeaponData" ), item => ( Weapon ) item );
    }

    //  Load asset from file
    public T LoadAsset < T > ( string path )
    {
        return ( T ) Convert.ChangeType ( Resources.Load ( path ), typeof ( T ) );
    }

    //  Get weapon from array
    public Weapon GetWeapon ( int id )
    {
        foreach ( Weapon weapon in weapons )
        {
            if ( weapon.id == id )
                return weapon;
        }

        return null;
    }
}
