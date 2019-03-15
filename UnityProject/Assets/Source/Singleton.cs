using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static ResourceManager resource_manager = null;

    public static ResourceManager GetResourceManager ( )
    {
        if ( resource_manager == null )
            resource_manager = new ResourceManager ( );

        return resource_manager;
    }
}
