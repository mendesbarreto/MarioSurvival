using UnityEngine;
using System.Collections;

public class MarioInputSystem : MonoBehaviour {

    private MarioInputComponent m_marioInputComponent;

    public void Start()
    {
        m_marioInputComponent = gameObject.GetComponent<MarioInputComponent>(); 
    }

	// Update is called once per frame
    public void Update()
    {
        m_marioInputComponent.axisX = Input.GetAxis("Horizontal");
        m_marioInputComponent.axisY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(MarioInputComponent.JUMP) || Input.GetKeyDown( KeyCode.Space ) )
        {
            m_marioInputComponent.jump = true;
        }
        else if (Input.GetKeyUp(MarioInputComponent.JUMP) || Input.GetKeyUp(KeyCode.Space))
        { 
            m_marioInputComponent.jump = false;
        }
        
        if (Input.GetKeyDown(MarioInputComponent.RIGHT) ||
            m_marioInputComponent.axisX > 0.0f )
        {
            m_marioInputComponent.right = true;
            m_marioInputComponent.left = false;
        }
        else if (Input.GetKeyDown(MarioInputComponent.LEFT) ||
            m_marioInputComponent.axisX < 0.0f )
        {
            m_marioInputComponent.right = false;
            m_marioInputComponent.left = true;
        }
        else
        {
            m_marioInputComponent.right = false;
            m_marioInputComponent.left = false;
        }

        if (Input.GetKeyDown(MarioInputComponent.RUN))
        {
            m_marioInputComponent.run = true;
        }
        else if (Input.GetKeyUp(MarioInputComponent.RUN))
        {
            m_marioInputComponent.run = false;
        }

        if (Input.GetKeyDown(MarioInputComponent.FIRE))
        {
            m_marioInputComponent.fire = true;
        }
        else if (Input.GetKeyUp(MarioInputComponent.FIRE))
        {
            m_marioInputComponent.fire = false;
        }

    }

}
