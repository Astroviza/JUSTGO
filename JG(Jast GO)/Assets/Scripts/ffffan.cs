using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ffffan : MonoBehaviour
{
        [SerializeField] Vector3 windDirection;
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(windDirection, ForceMode.Acceleration);    
    }
}
