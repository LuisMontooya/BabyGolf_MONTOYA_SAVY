using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncapPhysicsSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb == null) {
            Debug.LogError("No Rigid Body found. " + gameObject.name);
            return;
        }

        rb.maxAngularVelocity = Mathf.Infinity;

        Destroy(this);
    }

}
