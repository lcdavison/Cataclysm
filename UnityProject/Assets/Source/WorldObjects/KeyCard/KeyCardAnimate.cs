using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardAnimate : MonoBehaviour
{
    private Vector3 start_point;
    private Vector3 end_point;
    private float delta = 0.0f;
    private float change = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        start_point = end_point = transform.position;
        end_point.y += 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        delta += change;

        if ( delta >= 1.0f )
            change = -0.01f;
        else if ( delta <= 0.0f )
            change = 0.01f;

        Vector3 position = transform.position;
        position.y = 1.0f + Mathf.Sin ( delta );
        transform.position = position;
    }
}
