using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrasholdTrigger : MonoBehaviour
{
    [SerializeField] private Transform point1;
    
    [Range(-1,1)]
    [SerializeField] private float trashHold;

    private void OnDrawGizmos()
    {
        Vector3 targetVector3 = transform.position - point1.position;
        float dir = Vector3.Dot( targetVector3.normalized, point1.right);
        
        if (dir>=trashHold)
        {
            Gizmos.color = Color.red;
        }
        
        Gizmos.DrawRay(point1.position, point1.right);
    }
}
