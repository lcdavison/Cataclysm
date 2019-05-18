using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardAnimate : MonoBehaviour
{
    private Vector3 start_point;    //  Start point for the keycard
    private Vector3 end_point;  //  End point for the keycard
    private float delta = 0.0f; //  Provided to sine function
    private float change = 0.01f;   //  Amount to change delta by

    // Start is called before the first frame update
    void Start ( )
    {
        //  Setup movement markers
        start_point = end_point = transform.position;
        end_point.y += 5.0f;
    }

    // Update is called once per frame
    void Update ( )
    {
        delta += change;

        //  Toggle direction
        if ( delta >= 1.0f )
            change = -0.01f;
        else if ( delta <= 0.0f )
            change = 0.01f;

        //  Move the keycard up and down
        Vector3 position = transform.position;
        position.y = 1.0f + Mathf.Sin ( delta );
        transform.position = position;
    }
}
