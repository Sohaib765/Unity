using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowbuttonHold;
    private int bulletsLeft, bulletsShot;

    private Vector3 direction;

    //Bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject bulletholeGraphics;
    private CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;

    public ParticleSystem muzzleFlash;

    GameObject effect;
    public LineRenderer bulletTrail;

    //Animations
    [SerializeField] private Animator anim;
    [SerializeField] private Animator animUI;

    //UI
    public TextMeshProUGUI ammoLeft_TXT;
    public TextMeshProUGUI magazineSize_TXT;
    public TextMeshProUGUI reloadTXT_UI;

    //Sound
    [SerializeField] private AudioSource shootingSound;
    [SerializeField] private AudioSource reloadingSound;

    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize; 

    private void Start()
    {
        //anim = GetComponentInChildren<Animator>();

        camShake = GameObject.Find("MainCamera").GetComponent<CameraShake>();
    }

    private void Awake()
    {
        currentClip = maxClipSize;

        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red);

        //Playes "Low ammo fading animation" when the bullets are less than 5
        if(currentClip < 5)
        {
            animUI.SetBool("isLowAmmo", true);
        }
        else
        {
            animUI.SetBool("isLowAmmo", false);
        }

        if (currentClip < 10)
        {
            reloadTXT_UI.gameObject.SetActive(true);
        }
    }

    //Input function
    private void MyInput()
    {
        if (allowbuttonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && currentClip < maxClipSize && !reloading)
        {
            Reload();
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && currentClip > 0)
        {
            Shoot();

            //Playes "Increase font animation" whenever the player shoots
            animUI.SetTrigger("FontIncrease");

            ammoLeft_TXT.SetText(currentAmmo.ToString());
            magazineSize_TXT.SetText(currentClip.ToString());

            shootingSound.Play();

            //Shooting animation
            anim.SetTrigger("isShooting");
        }
    }

    //Shooting funtion
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy") || rayHit.collider.CompareTag("GB_Obj"))
            {
                //rayHit.collider.GetComponent<ShootingAI>().TakeDamage(damage);
                Debug.Log("You hit an enemy");

                //Add some force to the object when being hit
                var force = 20f;
                Rigidbody rb = rayHit.collider.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * force, ForceMode.Impulse);
            }

            BulletSpawnTrail(rayHit.point);
        }
        //Shake camera
        camShake.AnimationTrigger();
        if (camShake == null)
        {
            Debug.Log("Camera shake is null");
        }

        //Bullet impact effect
        effect = Instantiate(bulletholeGraphics, rayHit.point, Quaternion.LookRotation(rayHit.normal));
        effect.transform.SetParent(rayHit.collider.transform);
        Destroy(effect, 5f);

        //Muzzle flash effect while shooting
        muzzleFlash.Play();

        currentClip--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }

        
    }
    //Resetting shot function
    private void ResetShot()
    {
        readyToShoot = true;

        //Shooting animation
        anim.SetBool("isShooting", false);
    }

    //Reloading function
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

        

        if (currentAmmo != 0)
        {
            anim.SetBool("isReloading", true);
            reloadingSound.Play();
        }
        if(currentAmmo == 0)
        {
            anim.SetBool("isReloading", false);
        }
    }

    //Reloading finished function
    private void ReloadFinished()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;

        ammoLeft_TXT.SetText(currentAmmo.ToString());
        magazineSize_TXT.SetText(currentClip.ToString());

        reloadTXT_UI.gameObject.SetActive(false);

        reloading = false;

        anim.SetBool("isReloading", false);
    }

    //Instantiate a trail effect on the bullet
    private void BulletSpawnTrail(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, attackPoint.position, Quaternion.identity);

        LineRenderer lineR = bulletTrail.GetComponent<LineRenderer>();

        lineR.SetPosition(0, attackPoint.position);
        lineR.SetPosition(1, hitPoint);

        lineR.useWorldSpace = true;

        Destroy(bulletTrailEffect, 5f);
    }
}