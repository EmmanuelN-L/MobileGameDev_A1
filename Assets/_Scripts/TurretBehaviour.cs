using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    public float range = 15.0f;
    public float fireRate = 1.0f;
    public float fireCountdown = 0.0f;
    
    [Header("Unity Seup Fields")]
    
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10.0f;

    public GameObject AmmoPrefab;
    public Transform firePoint;
    public Transform firePoint2 = null;
    public bool RedTurret = false;

    public AudioSource fire1;

    // Start is called before the first frame update
    void Start()
    {
        fire1 = GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }
    //Updating target for turret to lock on to
    void UpdateTarget ()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Looping through enemies and checking the distance from each one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //If enemy distance is less than the current shorttest distance than change nearest enemy to that one
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //If the nearest anemy is not equal to null nad if the nearest emey is within range than target nearest enemy
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //If there is no target than return
        if (target == null)
        {
            return;
        }
    
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, q, Time.deltaTime * turnSpeed);

        if (fireCountdown <= 0.0f)
        {
            Shoot();
            fireCountdown = 1.0f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot ()
    {   //Red Turret
        if (RedTurret)
        {
            //Red Turret has 2 barrels so bullets will be coming out of both
            GameObject bulletGO = (GameObject)Instantiate(AmmoPrefab, firePoint.position, firePoint.rotation);
            GameObject bulletGO2 = (GameObject)Instantiate(AmmoPrefab, firePoint2.position, firePoint2.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            Bullet bullet2 = bulletGO2.GetComponent<Bullet>();
            fire1.Play();
            if (bullet != null && bullet2 != null)
            {
                bullet.Seek(target);
                bullet2.Seek(target);
            }
        } 
        //Green Turret
        else
        {
            GameObject bulletGO = (GameObject)Instantiate(AmmoPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            fire1.Play();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }

    //This function allows you to see a sphere range, this will be the range of my turret
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
