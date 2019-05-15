using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static byte keymask = 0;

    public static void AddKeyCard ( KeyCard keycard )
    {
        keymask |= (byte) keycard.GetColor ( );
    }

    public static byte GetKeyMask ( )
    {
        return keymask;
    }
}
