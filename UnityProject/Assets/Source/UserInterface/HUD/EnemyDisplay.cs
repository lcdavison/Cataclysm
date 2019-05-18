using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private Slider health_bar;  //  Enemy health bar
    private Text enemy_info;    //  Enemy text info
    private CanvasGroup group;  //  Enemy UI group

    // Start is called before the first frame update
    void Start ( )
    {
        //  Get UI elements
        health_bar = gameObject.GetComponentInChildren < Slider > ( );
        enemy_info = gameObject.GetComponentInChildren < Text > ( );
        group = gameObject.GetComponent < CanvasGroup > ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        Enemy enemy = player.GetClosestEnemy ( );

        //  If there is an enemy in front of the player, display their information
        if ( enemy != null )
        {
            EnemyData data = enemy.GetData ( );

            group.alpha = 1.0f; //  Show the UI
            health_bar.value = enemy.GetHealth ( ) / data.health;
            enemy_info.text = data.name + " Level " + System.Convert.ToString ( data.level );
        }
        else
        {
            group.alpha = 0.0f; //  Hide the UI
        }
    }
}
