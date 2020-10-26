using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float bulletSpeed = 50.0f;
    public int damage;
    public GameObject impactEffect;

   
    public void Seek(Transform _target)
    {
        target = _target;
    } 

    // Update is called once per frame
    void Update()
    {
        //If there's no target then bullet is destroyed e.g. Enemy makes it to the end
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        //If bullet has reached its target 
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }
    //This function allows for enemies to take damage based on the bullet type
    void Damage(Transform enemyGO)
    {
       Enemy enemy = enemyGO.GetComponent<Enemy>();
        //Making sure enemy isn't null for some reason
        if (enemy != null)
        {
            //Calls the function within enemy so that damage can be taken
            enemy.TakeDamage(damage);
        }
    }
    //When target is hit destroy the bullet create the paricle effect and call the damage function
    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2.0f);
        Damage(target);
        //Destroy(target.gameObject);
        Destroy(gameObject);

    }
}
