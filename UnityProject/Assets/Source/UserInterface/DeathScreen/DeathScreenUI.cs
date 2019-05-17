using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public void OnClickRestart ( )
    {
        SceneManager.LoadScene ( "LevelOne" );
    }

    public void OnClickExit ( )
    {
        SceneManager.LoadScene ( "MainMenu" );
    }
}
