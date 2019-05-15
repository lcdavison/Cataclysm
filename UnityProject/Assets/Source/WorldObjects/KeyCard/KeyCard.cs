using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField]
    private Key.COLOR color;

    void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            GameManager.AddKeyCard ( this );
            GameObject.Destroy ( this.gameObject );
        }
    }

    public Key.COLOR GetColor ( )
    {
        return color;
    }
}
