using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDontShootWall : MonoBehaviour
{
    public LayerMask[] masks;
    public LayerMask playerMask;

    private Ray ray;
    private AiAgent agent;

    private Vector3 origin;
    private Vector3 direction;
    private void Update()
    {
          
    }
}
