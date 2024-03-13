using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float projectileSpeed = 10f;
    public float cooldown = 1f; // Cooldown between shots

    private float lastShotTime;

    private void Update()
    {
        // Check if the player presses the fire button and if enough time has passed since the last shot
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShotTime + cooldown)
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        // Spawn a projectile at the launch point
        GameObject projectileInstance = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        
        // Get the rigidbody of the projectile
        Rigidbody projectileRigidbody = projectileInstance.GetComponent<Rigidbody>();
        
        // Check if the projectile has a rigidbody
        if (projectileRigidbody != null)
        {
            // Apply velocity to the projectile
            projectileRigidbody.velocity = launchPoint.forward * projectileSpeed;
        }
        
        // Update the last shot time
        lastShotTime = Time.time;
    }
}
