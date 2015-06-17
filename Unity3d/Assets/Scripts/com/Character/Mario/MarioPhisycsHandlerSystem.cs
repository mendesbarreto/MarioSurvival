using UnityEngine;
using System.Collections;

public class MarioPhisycsHandlerSystem : MonoBehaviour {

    private string m_groundTag = "ground";

    private Rigidbody2D m_marioRigidbody;
    private Character m_marioCharacter;
    
    
	// Use this for initialization
	void Start () {
        GameObject marioGO = GameObject.Find("Mario") ;
        m_marioRigidbody = marioGO.GetComponent<Rigidbody2D>();
        m_marioCharacter = marioGO.GetComponent<Character>();
	}

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector2(0, -1), 0.02f, 1 << LayerMask.NameToLayer("Ground") );
        Debug.DrawLine(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y- 0.02f));

        if (hit.collider != null)
            Debug.Log("Hit on: " + hit.collider.tag);

        if (hit != null && hit.collider != null && hit.collider.tag == m_groundTag)
            m_marioCharacter.isGrounded = true;
        else
            m_marioCharacter.isGrounded = false;

        Debug.Log("On: " + m_marioCharacter.isGrounded);
    }


//     public void OnTriggerEnter2D(Collider2D other)
//     {
//         if (m_groundTag == other.tag)
//         {
//             m_marioCharacter.isGrounded = true;
//         }
//     }
// 
//     public void OnTriggerExit2D(Collider2D other)
//     {
//         if (m_groundTag == other.tag)
//         {
//             m_marioCharacter.isGrounded = false;
//         }
//             
//    
    
    
}
