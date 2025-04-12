using UnityEngine;
using TMPro; // Add this for TextMeshPro support

public class ShapeSelectionManager : MonoBehaviour
{
    public GameObject sphere;  // Correct Shape
    public GameObject cube;    // Incorrect Shape
    public GameObject capsule; // Incorrect Shape
    public AudioSource audioSource;  // Optional for sound feedback
    public AudioClip correctClip;    // Audio clip for correct selection
    public AudioClip incorrectClip;  // Audio clip for incorrect selection
    public TextMeshProUGUI feedbackText; // Reference to FeedbackText UI element

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (feedbackText != null)
        {
            feedbackText.text = ""; // Initialize FeedbackText
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left-click or tap on the screen
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == sphere)  // Correct answer
                {
                    Debug.Log("Correct shape selected: ");
                    feedbackText.text = "Correct!";
                    feedbackText.color = Color.green; // Make text green for correct
                    audioSource.PlayOneShot(correctClip);
                }
                else  // Incorrect answer
                {
                    Debug.Log("Incorrect shape selected: " + hit.collider.gameObject.name);
                    feedbackText.text = "Incorrect!";
                    feedbackText.color = Color.red; // Make text red for incorrect
                    audioSource.PlayOneShot(incorrectClip);
                }
            }
        }
    }
}
