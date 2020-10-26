using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    public int Health = 100;

    private Transform target;
    private int waypointIndex = 0;
    public int moneyDrop = 5;
    public int addedScore = 5;

    public AudioSource Explosion;

    //Waypoints is what the enmies are following 
    void Start ()
    {
        Explosion = GetComponent<AudioSource>();
        target = Waypoints.points[0];
    }

    public void TakeDamage (int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Die();
        }
    }
    //When the enmemy dies
    void Die()
    {
        //Adding money to the player when they destroy a plane, adding to the user score and destroying the game object
        PlayerStats.userMoney += moneyDrop;
        PlayerStats.userScore += 5;
        Destroy(gameObject);
        Explosion.Play();
    }



    //In the update the enemy will translate to the waypoint, once it's reached it will set the new waypoint for it to follow
    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    //If there is no more waypoints left in the arry this means the enemy has reached it's destination and the player will lose health
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        //Increasing the wavepoint index for the enemy to follow the new destination
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {   //Players loses health
        Destroy(gameObject);
        PlayerStats.userHealth -= 10;

        if (PlayerStats.userHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
