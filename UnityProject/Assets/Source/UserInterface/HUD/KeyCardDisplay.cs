﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCardDisplay : MonoBehaviour
{
    [SerializeField]
    private Image blue_keycard;

    [SerializeField]
    private Image red_keycard;

    // Start is called before the first frame update
    void Start()
    {
        ToggleAlpha ( blue_keycard, 0.0f );
        ToggleAlpha ( red_keycard, 0.0f );
    }

    // Update is called once per frame
    void LateUpdate ( )
    {
        foreach ( KeyCard key in GameManager.keycards )
        {
            switch ( key.GetColor ( ) )
            {
                case KeyCard.KEYCOLOR.RED:
                    ToggleAlpha ( red_keycard, 1.0f );
                    break;
                case KeyCard.KEYCOLOR.BLUE:
                    ToggleAlpha ( blue_keycard, 1.0f );
                    break;
            }
        }
    }

    private void ToggleAlpha ( Image key_image, float value )
    {
        Color new_color = key_image.color;
        new_color.a = value;
        key_image.color = new_color;
    }
}