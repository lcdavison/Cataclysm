using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private Slider health_bar;
    private Text enemy_info;
    private CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        health_bar = gameObject.GetComponentInChildren < Slider > ( );
        enemy_info = gameObject.GetComponentInChildren < Text > ( );
        group = gameObject.GetComponent < CanvasGroup > ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        Enemy enemy = player.GetClosestEnemy ( );

        if ( enemy != null )
        {
            EnemyData data = enemy.GetData ( );

            group.alpha = 1.0f;
            health_bar.value = enemy.GetHealth ( ) / data.health;
            enemy_info.text = data.name + " Level " + System.Convert.ToString ( data.level );
        }
        else
        {
            group.alpha = 0.0f;
        }
    }
}
