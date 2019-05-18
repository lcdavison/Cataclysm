using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    //  Start the game
    public void PlayOnClick ( )
    {
        SceneManager.LoadScene ( "LevelOne" );
    }

    //  Close the game
    public void ExitOnClick ( )
    {
        Application.Quit ( );
    }
}
