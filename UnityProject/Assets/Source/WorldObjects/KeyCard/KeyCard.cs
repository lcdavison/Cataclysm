using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField]
    private Key.COLOR color;

    //  Check for game objects entering the trigger
    void OnTriggerEnter ( Collider other )
    {
        //  Check other game object is player
        if ( other.gameObject.tag == "Player" )
        {
            //  Collect keycard
            GameManager.AddKeyCard ( this );
            GameObject.Destroy ( this.gameObject );
        }
    }

    //  Get the color of the keycard
    public Key.COLOR GetColor ( )
    {
        return color;
    }
}
