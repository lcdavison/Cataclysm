using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public void PlayOnClick ( )
    {
        SceneManager.LoadScene ( "LevelOne" );
    }

    public void ExitOnClick ( )
    {
        Application.Quit ( );
        Debug.Log ( "Quit Clicked" );
    }
}
