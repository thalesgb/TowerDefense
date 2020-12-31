using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    public float startHealth = 100; 
    private float health;
    public Image healthBar;
    public int money = 50;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target  = Waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage (int amount){
        health -= amount;
        Debug.Log("STILL GOT "+health.ToString()+" HEALTH");
        Debug.Log("MY STARTING HEALTH WAS "+startHealth.ToString());
        Debug.Log("I TAKE  "+amount.ToString()+" DAMAGE");
        Debug.Log((health / startHealth).ToString());
        healthBar.fillAmount = health / startHealth ;

        if(health <= 0)
            Die();
    }

    void Die(){
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += money;
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f){
            GetNextWaypoint();
        }
    }
    
    void GetNextWaypoint(){

        if(wavepointIndex >= Waypoints.points.Length - 1){
            PathEnd();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void PathEnd(){
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
