using UnityEngine;
using System.Collections;

public class MarioInputComponent : MonoBehaviour {

    public bool jump;
    public bool left;
    public bool right;
    public bool fire;
    public bool run;
    public float axisX;
    public float axisY;

    public static KeyCode UP = KeyCode.UpArrow ;
    public static KeyCode DOWN = KeyCode.DownArrow;
    public static KeyCode LEFT = KeyCode.LeftArrow;
    public static KeyCode RIGHT = KeyCode.RightArrow;

    public static KeyCode JUMP = KeyCode.Joystick1Button0;
    public static KeyCode FIRE = KeyCode.Joystick1Button2;
    public static KeyCode RUN = KeyCode.Joystick1Button2;
}
