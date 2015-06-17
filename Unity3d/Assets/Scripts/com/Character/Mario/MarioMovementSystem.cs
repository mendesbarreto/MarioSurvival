using UnityEngine;
using System.Collections;

public class MarioMovementSystem : MonoBehaviour
{
    public static readonly float MAX_SPEED_X = 2F;
    public static readonly float MAX_RUN_SPEED_X = 1F;
    public static readonly float MAX_SPEED_Y = 3F;
    public static readonly float SPEED = 2F;

    [SerializeField]
    protected Character m_marioCharacter;
    
    [SerializeField]
    protected MarioInputComponent m_marioInput;

    [SerializeField]
    protected Rigidbody2D m_characterRigidbody;

    [SerializeField]
    protected Transform m_characterTransform;

    [SerializeField]
    protected float m_nextPosX;


    [SerializeField]
    protected float m_aceleration;

    [SerializeField]
    protected float m_speedY;

    protected float m_gravity = -1.2f;

    private float m_runSpeed = 0;

    // Use this for initialization
    void Start()
    {
        m_marioCharacter = gameObject.GetComponent<Character>();
        m_marioInput = gameObject.GetComponent<MarioInputComponent>();
        m_characterRigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_characterTransform = gameObject.transform;
    }

    // Update is called once per frame
    public void Update()
    {
        VerifyGround();

        float L_currentSpeedX = m_characterRigidbody.velocity.x;
        float L_currentSpeedY = m_characterRigidbody.velocity.y;

        if( m_marioInput.right )
        {
            m_characterRigidbody.velocity = new Vector2(SPEED * m_marioInput.axisX + m_runSpeed, L_currentSpeedY);
            
            if (m_characterTransform.localScale.x < 0)
                FlipHorizontal();
        }
        else if ( m_marioInput.left )
        {
            m_characterRigidbody.velocity = new Vector2(SPEED * m_marioInput.axisX - m_runSpeed, L_currentSpeedY);
            
            if ( m_characterTransform.localScale.x > 0 )
                FlipHorizontal();
        }

        if( m_marioInput.jump )
        {
            Jump();
        }
        else
        {
            if (L_currentSpeedY > 1.1f && !m_marioCharacter.isFalling )
            {
                m_characterRigidbody.velocity = new Vector2(L_currentSpeedX, 1.1f);
            }    
        }

        if (L_currentSpeedY < 0)
            m_marioCharacter.isFalling = true;
        else
            m_marioCharacter.isFalling = false;

        m_speedY = L_currentSpeedY;

        if( m_marioInput.run )
        {
            m_runSpeed = MAX_RUN_SPEED_X;
        }
        else
        {
            m_runSpeed = 0;
        }

    }

    private void VerifyGround()
    {
        if (m_marioCharacter.isGrounded && m_characterRigidbody.velocity.y == 0)
        {
            m_marioCharacter.isJumping = false;
            m_marioCharacter.isFalling = false;
        }
    }

    private void FlipHorizontal()
    {
        m_characterTransform.localScale = new Vector3(-m_characterTransform.localScale.x, m_characterTransform.localScale.y, m_characterTransform.localScale.z);
    }

    static int count = 0;
    private const int JUMP_FORCE = 160;

    private void Jump()
    {
        if (m_marioCharacter.isJumping == false)
        {
            Debug.Log("Jump: " + count++);
            Vector2 pos = m_characterRigidbody.transform.position;
            m_characterRigidbody.transform.position = new Vector2(pos.x,pos.y + 0.1f);

            m_characterRigidbody.AddForce(new Vector2(0, JUMP_FORCE));
            m_marioCharacter.isJumping = true;
        }
    }
}
