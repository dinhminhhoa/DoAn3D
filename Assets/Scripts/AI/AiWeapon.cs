using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeapon : MonoBehaviour
{
    public float inAccurary = 0.0f;
    private RaycastWeapon currentWeapon;
    private Animator animator;
    private MeshSocketController socketController;
    private AiWeaponIK weaponIK;
    private Transform currentTarget;
    private bool weaponActive = false;
    public bool WeaponActive => weaponActive;

    private void Start()
    {
        animator = GetComponent<Animator>();
        socketController = GetComponent<MeshSocketController>();
        weaponIK = GetComponent<AiWeaponIK>();
    }

    private void Update()
    {
        if (currentTarget && currentWeapon && weaponActive)
        {
            Vector3 target = currentTarget.position + weaponIK.targetOffset;
            target += Random.insideUnitSphere * inAccurary;
            currentWeapon.UpdateWeapon(Time.deltaTime, target);
        }
    }

    public void SetFiring(bool enabled)
    {
        if (enabled)
        {
            currentWeapon.StartFiring();
        }
        else
        {
            currentWeapon.StopFiring();
        }
    }

    public void EquipWeapon(RaycastWeapon weapon)
    {
        
            currentWeapon = weapon;
            socketController.Attach(currentWeapon.transform, SocketID.RightLeg);
        
        
    }

    public void ActivateWeapon()
    {
        StartCoroutine(Equip());
    }

    private IEnumerator Equip()
    {
        animator.runtimeAnimatorController = currentWeapon.animator;
        animator.SetBool("Equip", true);
        yield return new WaitForSeconds(0.5f);
        while (animator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1.0f)
        {
            yield return null;
        }
        weaponIK.SetAimTransform(currentWeapon.raycastOrigin);
        weaponActive = true;
    }

    public void DeActivateWeapon()
    {
        SetTarget(null);
        SetFiring(false);
        StartCoroutine(Holster());
    }

    private IEnumerator Holster()
    {
        weaponActive = false;
        animator.SetBool("Equip", false);
        yield return new WaitForSeconds(0.5f);
        while (animator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1.0f)
        {
            yield return null;
        }
        weaponIK.SetAimTransform(currentWeapon.raycastOrigin);

    }

    public bool HasWeapon()
    {
        return currentWeapon != null;
    }

    public void DropWeapon()
    {
        if (currentWeapon)
        {
            currentWeapon.transform.SetParent(null);
            currentWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
            currentWeapon.gameObject.AddComponent<Rigidbody>();
            currentWeapon = null;
        }
    }

    public void OnAnimationEvent(string eventName)
    {
        if (eventName.Equals("equipWeapon"))
        {
            socketController.Attach(currentWeapon.transform, SocketID.RightHand);
        }
    }

    public void SetTarget(Transform target)
    {
        weaponIK.SetTargetTransform(target);
        currentTarget = target;
    }
}

