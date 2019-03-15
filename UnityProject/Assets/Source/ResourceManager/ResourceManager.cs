using System;
using System.Collections;
using UnityEngine;

public class ResourceManager
{
    public Weapon [] weapons;

    public void CacheWeapons ( )
    {
        weapons = Array.ConvertAll ( Resources.LoadAll ( "WeaponData" ), item => ( Weapon ) item );
    }

    public T LoadAsset<T> ( string path ) 
    {
        return ( T ) Convert.ChangeType ( Resources.Load ( path ), typeof ( T ) );
    }

    public Weapon GetWeapon ( int id )
    {
        foreach ( Weapon weapon in weapons )
        {
            if ( weapon.weapon_id == id )
                return weapon;
        }

        return null;
    }
}
