using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public void PlayOnClick()
    {
        //  TODO: Use SceneManager to load level
        Debug.Log ( "Play Clicked" );
    }

    public void ExitOnClick ()
    {
        Application.Quit ();
        Debug.Log ( "Quit Clicked" );
    }
}
