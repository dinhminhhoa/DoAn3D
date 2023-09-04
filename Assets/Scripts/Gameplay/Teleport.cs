using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform playerTranform, destianation;
    public GameObject playerTele;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // luu y : Object phai co rigibody moi teleport duoc
            playerTele.SetActive(false);       
            playerTranform.position = destianation.position;       
            playerTele.SetActive(true);
        }
    }

}
