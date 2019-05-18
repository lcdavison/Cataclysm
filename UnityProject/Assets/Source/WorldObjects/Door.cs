using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioSource door_sound; //  Door opening / closing sound

    [SerializeField]
    private float door_speed;   //  Door open / close speed

    [SerializeField]
    private Transform destination_marker;   //  Where to open to
    private Transform door; //  Door model

    [SerializeField]
    private Key.COLOR required_key; //  Key colour required to unlock the door

    [SerializeField]
    private bool locked = false;    //  Is the door locked?

    private Vector3 original_position;  //  Starting position
    private Vector3 destination;    //  Ending position

    //  Start is called before first frame update
    void Start ( )
    {
        //  Get door model
        door = transform.parent.gameObject.transform.GetChild ( 0 ).transform;

        //  Make sure door doesn't move yet
        original_position = door.position;
        destination = door.position;
    }

    // Update is called once per frame
    void Update ( )
    {
        //  Check whether the player has collected the key
        if ( ( GameManager.GetKeyMask ( ) & (byte) ( required_key ) ) > 0 )
        {
            locked = false;
        }

        //  Move while not at the door destination
        if ( destination != door.position )
        {
            //  Smoothly move between the two points
            door.position = Vector3.Lerp ( door.position, destination, door_speed * Time.deltaTime );
        }
    }

    //  Check for game objects entering the trigger
    void OnTriggerEnter ( Collider other )
    {
        //  Check other game object is player
        if ( other.gameObject.tag == "Player" && !locked )
        {
            //  Set destination and play sound
            destination = destination_marker.position;
            door_sound.Play ( );
        }
    }

    //  Check for game objects exiting the trigger
    void OnTriggerExit ( Collider other )
    {
        //  Check other game object is player
        if ( other.gameObject.tag == "Player" )
        {
            //  Set destination and play sound
            destination = original_position;
            door_sound.Play ( );
        }
    }
}
