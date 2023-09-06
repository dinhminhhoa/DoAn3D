//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerCheckPoint : Health
//{
//    public GameObject player;
//    private Vector3 spawmPoint;
//    private Health playerHealh;

//    private void Start()
//    {
//        spawmPoint = gameObject.transform.position;
//    }

//    private void Update()
//    {
//        if (  playerHealh.currentHealth <= 0)
//        {
//            gameObject.transform.position = spawmPoint;
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Checkpoint"))
//        {
//            spawmPoint = player.transform.position;
//            Destroy(gameObject);
//        }
//    }
//}
