using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Check for game objects entering trigger
    void OnTriggerEnter ( Collider other )
    {
        //  Checks other game object is the player
        if ( other.gameObject.tag == "Player" )
        {
            //  Unlock the cursor and load end scene
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene ( "End" );
        }
    }
}
