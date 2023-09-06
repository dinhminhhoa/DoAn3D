using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTelePoint : MonoBehaviour
{
    public Transform enemyTranform, destianation;
    public GameObject enemyTele;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // luu y : Object phai co rigibody moi teleport duoc
            enemyTele.SetActive(false);
            enemyTranform.position = destianation.position;
            enemyTele.SetActive(true);
        }
    }
}
