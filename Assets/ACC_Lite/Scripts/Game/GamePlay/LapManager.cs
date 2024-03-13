using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    public Transform playerCar; // Reference to the player's car
    public Transform[] checkpoints; // Array of checkpoints representing the track
    public TextMeshProUGUI lapCounterText; // TextMeshPro UI element to display lap count

    private int currentCheckpointIndex = 0;
    private int lapCount = 0;

    public void CrossedFinishLine()
    {
        // This method is called when the player car crosses the finish line
        currentCheckpointIndex = 0; // Reset the checkpoint index
        lapCount++; // Increment lap count
        lapCounterText.text = "Lap: " + lapCount; // Update lap counter text
    }

    void Update()
    {
        // Check if the player car passes through a checkpoint
        if (Vector3.Distance(playerCar.position, checkpoints[currentCheckpointIndex].position) < 5f)
        {
            currentCheckpointIndex++;

            // If the player passes the last checkpoint, call CrossedFinishLine method
            if (currentCheckpointIndex >= checkpoints.Length)
            {
                CrossedFinishLine();
            }
        }
    }
}
