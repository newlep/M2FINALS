using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public enum PowerUpType
    {
        SpeedBoost,
        Projectile,
        Shield
        // Add more power-up types as needed
    }

    public PowerUpType powerUpType;
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float rotationSpeed = 100f;
    public float projectileSpeed = 10f;
    public float cooldown = 1f; // Cooldown between shots

    private float lastShotTime;

    private void Update()
    {
        // Rotate the power-up object
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player's car
        CarController carController = other.GetComponent<CarController>();
        if (carController != null)
        {
            // Apply the power-up effect based on its type
            switch (powerUpType)
            {
                case PowerUpType.SpeedBoost:
                    carController.ApplyTorqueBoost(100f, 5f); // Example values, adjust as needed
                    break;
                case PowerUpType.Projectile:
                    ShootProjectile();
                    break;
                case PowerUpType.Shield:
                    // Implement logic for activating shields
                    break;
                // Add more cases for additional power-up types
            }

            // Destroy the power-up object after it's picked up
            Destroy(gameObject);
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
