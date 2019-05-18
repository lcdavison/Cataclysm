using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    //  Restart the level
    public void OnClickRestart ( )
    {
        SceneManager.LoadScene ( "LevelOne" );
    }

    //  Exit to the main menu
    public void OnClickExit ( )
    {
        SceneManager.LoadScene ( "MainMenu" );
    }
}
