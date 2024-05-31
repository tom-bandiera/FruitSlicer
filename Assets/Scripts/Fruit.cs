using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    public bool AllowsSlice { get; private set; }
    [SerializeField] private Material m_defaultMaterial;
    [SerializeField] private GameObject m_modelFruit;
    [SerializeField] private Transform m_container;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);
        AllowsSlice = true;
    }

    private void Update()
    {
        if (transform.position.y < -30)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetupHull(GameObject _hull)
    {
        var lowerCollider = _hull.AddComponent<MeshCollider>();
        lowerCollider.enabled = true;
        lowerCollider.convex = true;
        var rigidBody = _hull.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(300, rigidBody.position, 5, 0f);
        _hull.layer = 6;
        rigidBody.AddTorque(new Vector3(0, 10, 1));
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        var script = _hull.AddComponent<Fruit>();
        script.m_container = m_container;
        script.m_defaultMaterial = m_defaultMaterial;
        _hull.transform.parent = m_container;
    }

    public void Slice(Vector3 _position, Vector3 _normal)
    {
        var gameObjectToBeSlice = gameObject;
        var sliceHullData = gameObjectToBeSlice.Slice(_position, _normal);

        GameObject lowerHull = sliceHullData.CreateLowerHull(gameObjectToBeSlice, m_defaultMaterial);
        GameObject upperHull = sliceHullData.CreateUpperHull(gameObjectToBeSlice, m_defaultMaterial);

        SetupHull(lowerHull);
        SetupHull(upperHull);

        gameObject.SetActive(false);
    }
}
