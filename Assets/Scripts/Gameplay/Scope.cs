//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Scope : MonoBehaviour
//{
//    public Animator animator;
//    public GameObject scopeOverlay;

//    public GameObject weaponCamera;


//    private bool isScoped = false;

//    private void Update()
//    {
//        if (Input.GetButtonDown("Fire2"))
//        {
//            isScoped = !isScoped;
//            animator.SetBool("Scope", isScoped);

//            scopeOverlay.SetActive(isScoped);

//            if (isScoped)
//                StartCoroutine(OnScoped());
//            else
//                OnUnscoped();

//        }
//    }

//    public void OnUnscoped()
//    {
//        scopeOverlay.SetActive(false);
//        weaponCamera.SetActive(true);


//    }

//    public IEnumerator OnScoped()
//    {
//        yield return new WaitForSeconds(0.15f);

//        scopeOverlay.SetActive(true);
//        weaponCamera.SetActive(false);


//    }

//}
