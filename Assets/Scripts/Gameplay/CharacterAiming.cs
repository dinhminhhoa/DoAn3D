using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Experimental.GraphView;

public class CharacterAiming : MonoBehaviour
{
    private float turnSpeed;
    private float defaultRecoil;
    private float aimRecoil;
    public Transform cameraLookAt;
    public AxisState xAxis;
    public AxisState yAxis;
    public bool isAiming ;
   // private bool isScoped = false;

    private Camera mainCamera;
    private Animator animator;
    private ActiveWeapon activeWeapon;
    private int isAimingParam = Animator.StringToHash("IsAiming");
    

    public string weaponName;

    public GameObject scopeOverlay;

   

    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        activeWeapon = GetComponent<ActiveWeapon>();
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(DataManager.HasInstance)
        {
            turnSpeed = DataManager.Instance.GlobalConfig.turnSpeed;
            defaultRecoil = DataManager.Instance.GlobalConfig.defaultRecoil;
            aimRecoil = DataManager.Instance.GlobalConfig.aimRecoil;
        }
    }

    void Update()
    {
        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            if (activeWeapon.canFire && weapon.weaponName.Equals("Sniper"))
            {
                isAiming = Input.GetMouseButtonDown(1);
                animator.SetBool(isAimingParam, isAiming);

              if (isAiming)
             {
                    scopeOverlay.SetActive(true);                  
             }

              
                                        
               
               
                
            }
             


            else if (activeWeapon.canFire && weapon.weaponName.Equals("rilfe")) 
            {
                isAiming = Input.GetMouseButton(1);
                animator.SetBool(isAimingParam, isAiming);

                scopeOverlay.SetActive(false);
               // weapon.weaponRecoil.recoilModifier = isAiming ? aimRecoil : defaultRecoil;
            }
            weapon.weaponRecoil.recoilModifier = isAiming ? aimRecoil : defaultRecoil;
        }
    }

    private void FixedUpdate()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
    }

    public void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
       // weaponCamera.SetActive(true);
    }

    public IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlay.SetActive(true);
       // weaponCamera.SetActive(false);
    }
}
