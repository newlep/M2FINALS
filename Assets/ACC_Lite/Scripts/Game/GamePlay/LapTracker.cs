using UnityEngine;

public class LapTracker : MonoBehaviour
{
    public LapManager lapManager; // Reference to the LapManager script

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // Check if the collider belongs to a car
        {
            // Notify the LapManager that a car has crossed the lap line
            lapManager.CrossedFinishLine();
        }
    }
}
