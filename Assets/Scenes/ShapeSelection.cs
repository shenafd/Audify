using UnityEngine;
using UnityEngine.UI;

public class ShapeSelection : MonoBehaviour
{
    public Text feedbackText; // Reference to the UI Text component

    // Function to handle cube click
    public void OnCubeClicked()
    {
        feedbackText.text = "Incorrect! You selected Cube.";
        feedbackText.color = Color.red; // Optional: Change text color for incorrect
    }

    // Function to handle sphere click
    public void OnSphereClicked()
    {
        feedbackText.text = "Correct! You selected Sphere.";
        feedbackText.color = Color.green; // Optional: Change text color for correct
    }

    // Function to handle capsule click
    public void OnCapsuleClicked()
    {
        feedbackText.text = "Incorrect! You selected Capsule.";
        feedbackText.color = Color.red; // Optional: Change text color for incorrect
    }
}
