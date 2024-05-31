using UnityEngine;

public class Blade : MonoBehaviour
{
    private Vector3 m_mousePosition;
    private Vector3 m_mouseDirection;
    private bool m_isSlicing;
    private Camera m_mainCamera;
    [SerializeField] TrailRenderer m_trailRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        } else if (Input.GetMouseButtonUp(0)) {
            StopSlicing();
        } else if (m_isSlicing)
        {
            Slicing();
        }
    }

    private void StartSlicing()
    {
        m_isSlicing = true;
        m_trailRenderer.enabled = true;
        Cursor.visible = false;
    }

    private void StopSlicing()
    {
        m_isSlicing = false;
        m_trailRenderer.enabled = false;
        Cursor.visible = true;
    }

    private void Slicing()
    {
        m_mousePosition = Input.mousePosition;
        Vector3 newPosition = m_mainCamera.ScreenToWorldPoint(m_mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;
    }
}
