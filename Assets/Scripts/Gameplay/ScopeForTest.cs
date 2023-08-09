using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeForTest : MonoBehaviour
{
    public Animator animatorTest;
    public GameObject scopeOverlayTest;

    public GameObject weaponCameraTest;


    private bool isScopedTest = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScopedTest = !isScopedTest;
            animatorTest.SetBool("ScopeForTest", isScopedTest);

            scopeOverlayTest.SetActive(isScopedTest);

            if (isScopedTest)
                StartCoroutine(OnScopedTest());
            else
                OnUnscopedTest();

        }
    }

    void OnUnscopedTest()
    {
        scopeOverlayTest.SetActive(false);
        weaponCameraTest.SetActive(true);


    }

    IEnumerator OnScopedTest()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlayTest.SetActive(true);
        weaponCameraTest.SetActive(false);


    }

}
