using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Die_Instantiate_FinishPoint : MonoBehaviour
{
    public float health = 20f;
    public GameObject finishPoint;

    public void TakeDamage ( float amount)
    {
        health -= amount;
        if( health <=0f )
        {
            Instantiate(finishPoint);
            Destroy(this);
        }
    }
}
