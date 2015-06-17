using UnityEngine;
using System.Collections;

public class MarioHoldOjbectSystem : MonoBehaviour {

    public int OBJECT_SHELL = 1 << LayerMask.NameToLayer("Shell");
    public const float KICK_FORCE = 0.01f ;

    public MarioObjectHolded m_marioObj;
    public MarioInputComponent m_marioInput;
    public Character m_mario;
    public ObjectSpeedLimit m_objSpeedLimit;

	// Use this for initialization
	void Start () 
    {
        m_marioObj = gameObject.GetComponent<MarioObjectHolded>();
        m_mario = gameObject.GetComponent<Character>();
        m_marioInput = gameObject.GetComponent<MarioInputComponent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!m_mario.isHolding)
        {
            if( m_marioObj.obj != null)
            {
                EnableObjectColisions();

                m_objSpeedLimit = m_marioObj.obj.GetComponent<ObjectSpeedLimit>();
                m_marioObj.obj.transform.parent = null;

                Rigidbody2D rig = m_marioObj.obj.GetComponent<Rigidbody2D>();
                Vector3 position = m_marioObj.obj.transform.position;
                
                if (m_objSpeedLimit != null)
                { 
                    if( gameObject.transform.localScale.x > 0 )
                    { 
                        position = new Vector3(position.x + 0.2f, position.y, position.z);
                        rig.velocity = new Vector2(m_objSpeedLimit.speedLimitX, 0f);
                    }    
                    else
                    {
                        position = new Vector3(position.x - 0.2f, position.y, position.z);
                        rig.velocity = new Vector2(-m_objSpeedLimit.speedLimitX, 0f);
                    }
                }

                m_marioObj.obj.transform.position = position;
                m_marioObj.obj = null;
                m_objSpeedLimit = null;

                m_mario.isKicking = true;
            }
        }

        if (!m_marioInput.fire)
            m_mario.isHolding = false;
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (OBJECT_SHELL == (1 << coll.gameObject.layer))
        {
            if (m_marioInput.fire)
            {
                if (m_mario.isHolding == false)
                {
                    m_marioObj.obj = coll.gameObject;
                    m_mario.isHolding = true;

                    DisableObjectColisions();

                    m_marioObj.obj.transform.parent = gameObject.transform;

                    Vector3 shellHolderPosition = GameObject.Find("shellHolder").transform.position;
                    m_marioObj.obj.transform.position = shellHolderPosition;
                }
            }
        }
    }

    private void DisableObjectColisions()
    {
        Rigidbody2D rig = m_marioObj.obj.GetComponent<Rigidbody2D>();
        rig.isKinematic = true;
        rig.velocity = Vector3.zero;

        BoxCollider2D box = m_marioObj.obj.GetComponent<BoxCollider2D>();
        box.enabled = false;
    }

    private void EnableObjectColisions()
    {
        Rigidbody2D rig = m_marioObj.obj.GetComponent<Rigidbody2D>();
        rig.isKinematic = false;
        rig.velocity = Vector3.zero;

        BoxCollider2D box = m_marioObj.obj.GetComponent<BoxCollider2D>();
        box.enabled = true;
    }

    public void IngnoreMarioCollision( Collider2D coll )
    {
        Physics2D.IgnoreCollision(coll, gameObject.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(coll, gameObject.GetComponent<CircleCollider2D>());
    }

    public void ReturnMarioCollision(Collider2D coll)
    {
        Physics2D.IgnoreCollision(coll, gameObject.GetComponent<BoxCollider2D>(), false);
        Physics2D.IgnoreCollision(coll, gameObject.GetComponent<CircleCollider2D>(), false);
    }
    
}
