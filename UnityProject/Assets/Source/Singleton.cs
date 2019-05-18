using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static ResourceManager resource_manager = null;

    //  Returns the instance of the resource manager
    public static ResourceManager GetResourceManager ( )
    {
        //  If not created, create the resource manager
        if ( resource_manager == null )
            resource_manager = new ResourceManager ( );

        return resource_manager;
    }
}
