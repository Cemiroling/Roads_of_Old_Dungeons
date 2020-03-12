using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class DrawRaycast : MonoBehaviour
{

    public Vector2 end;

    public float radius;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
 
}
