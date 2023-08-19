using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showray : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position+ transform.forward * 50);
    }
}
