using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float door_speed;

    [SerializeField]
    private Transform destination_marker;
    private Transform door;

    private Vector3 original_position;
    private Vector3 destination;

    void Start ( )
    {
        door = transform.parent.gameObject.transform.GetChild ( 0 ).transform;
        original_position = door.position;
        destination = door.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ( destination != door.position )
        {
            door.position = Vector3.Lerp ( door.position, destination, door_speed * Time.deltaTime );
        }
    }

    void OnTriggerEnter ( Collider collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            destination = destination_marker.position;
        }
    }

    void OnTriggerExit ( Collider collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            destination = original_position;
        }
    }
}
