using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float boostTorque = 500f; // Amount of torque boost to apply
    [SerializeField] private float boostDuration = 2f; // Duration of the torque boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // Assuming the player's car has a tag "Player", adjust as needed
        {
            CarController carController = other.GetComponent<CarController>(); // Assuming your car controller script is named CarController
            if (carController != null)
            {
                carController.ApplyTorqueBoost(boostTorque, boostDuration);
                // You can add effects here if you want, like particle effects or sound effects
                // For example, you can play a sound effect when the boost is activated
                // You can also disable the boost object if you want it to be a one-time use
                gameObject.SetActive(false);
            }
        }
    }
}
