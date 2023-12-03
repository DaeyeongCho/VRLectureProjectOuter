using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoColliderCollision : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    void Start()
    {
        Collider collider1 = object1.GetComponent<Collider>();
        Collider collider2 = object2.GetComponent<Collider>();

        Physics.IgnoreCollision(collider1, collider2);
    }
}