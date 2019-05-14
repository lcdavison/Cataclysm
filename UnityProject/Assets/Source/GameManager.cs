using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List < KeyCard > keycards = new List < KeyCard > ( );

    public static void AddKeyCard ( KeyCard keycard )
    {
        keycards.Add ( keycard );
    }
}
