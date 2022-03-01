using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadiaTrigger : MonoBehaviour
{
    public Transform targetPoint;
    private float radius = 2f;
    
    private void OnDrawGizmos()
    {
        Vector3 vectorToTarget = targetPoint.position - transform.position;
       //Gizmos.DrawRay(transform.position, vectorToTarget.normalized);
       //Gizmos.DrawRay(transform.position, vectorTarget.position);

        float fds = Mathf.Sqrt(Mathf.Pow(vectorToTarget.y,2)+Mathf.Pow(vectorToTarget.x,2));

        if (fds<radius)
        {
            Handles.color = Color.red;
        }
        else
        {
            Handles.color = Color.white;
        }
        
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}
