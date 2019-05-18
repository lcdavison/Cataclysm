using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static byte keymask = 0;    //  Used to store the status of the keys in the game

    //  Adds a collected key to the keymask
    public static void AddKeyCard ( KeyCard keycard )
    {
        keymask |= (byte) keycard.GetColor ( );
    }

    //  Returns the keymask
    public static byte GetKeyMask ( )
    {
        return keymask;
    }
}
