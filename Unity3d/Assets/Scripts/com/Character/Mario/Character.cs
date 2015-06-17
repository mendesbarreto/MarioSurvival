using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
    public static float SMALL = 0f;
    public static float TALL = 1f;
    public static float FIREMAN = 2f;

    public float currentState = TALL;

    public bool isJumping = false;
    public bool isGrounded = false;
    public bool isFalling = false;
    public bool isHolding = false;
    public bool isKicking = false;

}
