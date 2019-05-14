using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public enum KEYCOLOR
    {
            RED = 0x1,
            BLUE = 0x2
    };

    [SerializeField]
    private KEYCOLOR color;

    void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.tag == "Player" )
        {
            GameManager.AddKeyCard ( this );
            GameObject.Destroy ( this.gameObject );
        }
    }

    public KEYCOLOR GetColor ( )
    {
        return color;
    }
}
