using EzySlice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlashDetector : MonoBehaviour
{
    private Vector3 m_previousPosition;
    private Vector3 m_normalVector;

    [SerializeField] private GameObject m_slashSVFXPrefab;
    private Transform m_transform;

    private void Awake()
    {
        m_transform = transform;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            m_previousPosition = m_transform.position; ;
            yield return new WaitForSeconds(.05f);

            var currentPosition = m_transform.position; ;
            var moveDirection = Vector3.Normalize(currentPosition - m_previousPosition);
            m_normalVector = Vector3.Cross(Vector3.back, moveDirection);

        }
    }

    // Update is called once per frame
    void Update()
    {
/*        Debug.DrawLine(transform.position, transform.position + m_moveDirection * m_moveSpeed * 100);
        Debug.DrawLine(transform.position, transform.position + m_normal * m_moveSpeed * 10);*/
    }

    private void OnTriggerEnter(Collider _object)
    {
        var gameObjectToBeSlice = _object.gameObject;
        var fruitController = gameObjectToBeSlice.GetComponent<Fruit>();

        if (fruitController == null) return;
        if (fruitController.AllowsSlice == false) return;
        try
        {
            var position = m_transform.position;
            fruitController.Slice(position, m_normalVector);
            Instantiate(m_slashSVFXPrefab, position, Quaternion.identity);

        }
        catch (Exception _e)
        {
            Debug.LogWarning(_e.Message);
        }

        // _object.GetComponent<Fruit>().Slice(transform.position, m_normal);
    }
}
