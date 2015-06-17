using UnityEngine;
using System.Collections;

public class CameraResizer : MonoBehaviour {

    private float m_lastHeight = 0;

	// Use this for initialization
	public void Start () 
    {
        Resize();
        m_lastHeight = Screen.height;
	}

    public void Update()
    {
        if (m_lastHeight != Screen.height)
            Resize();
    }

    public void Resize()
    {
        gameObject.GetComponent<Camera>().orthographicSize = (Screen.height * 0.5f) * 0.01f;
    }

}
