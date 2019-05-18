using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    [SerializeField]
    private GameObject to_activate; //  Button to activate on completion

    [SerializeField]
    private Text text_output;   //  Where to print the characters

    private byte message_marker = 0;    //  Index of current character in message

    private float last_time = 0;    //  The last update time

    private string message = "Congratulations"; //  Message to display

    private bool finished = false;  //  Has message printing finished?

    // Update is called once per frame
    void Update ( )
    {
        //  Over 2 seconds show the message
        float current_time = Time.time;
        if ( Time.time - last_time > ( 2.0f / 15.0f ) )
        {
            PrintNextCharacter ( );
            last_time = current_time;
        }

        //  Activate another game object when finished
        if ( finished )
        {
            to_activate.SetActive ( true );
        }
    }

    //  Print the next character in the message
    void PrintNextCharacter ( )
    {
        //  Check if the message has been fully printed
        if ( message_marker < message.Length )
            text_output.text += message [ message_marker++ ];
        else
            finished = true;
    }
}
