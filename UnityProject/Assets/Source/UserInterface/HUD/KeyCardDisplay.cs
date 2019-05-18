using System.Collections;
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
    void Start ( )
    {
        //  Hide the images
        SetAlpha ( blue_keycard, 0.0f );
        SetAlpha ( red_keycard, 0.0f );
    }

    // Update is called once per frame
    void LateUpdate ( )
    {
        //  Determine which key cards should be displayed
        switch ( GameManager.GetKeyMask ( ) )
        {
            case 0x1:
                SetAlpha ( red_keycard, 1.0f );
                break;
            case 0x2:
                SetAlpha ( blue_keycard, 1.0f );
                break;
            case 0x3:
                SetAlpha ( red_keycard, 1.0f );
                SetAlpha ( blue_keycard, 1.0f );
                break;
        }
    }

    //  Set alpha value for an image
    private void SetAlpha ( Image key_image, float value )
    {
        Color new_color = key_image.color;
        new_color.a = value;
        key_image.color = new_color;
    }
}
