using UnityEngine;

public class ShapeSelectionManager : MonoBehaviour
{
    public GameObject sphere;  // Correct Shape
    public GameObject cube;    // Incorrect Shape
    public GameObject capsule; // Incorrect Shape
    public AudioSource audioSource;  // Optional for sound feedback
    public AudioClip correctClip;   // Audio clip for correct selection
    public AudioClip incorrectClip; // Audio clip for incorrect selection

    void Start()
    {
        // Optional: initialize the audio source here if not assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Detect touch or mouse click
        if (Input.GetMouseButtonDown(0))  // Left-click or tap on the screen
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if raycast hits any of the shapes
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == sphere)  // Correct answer
                {
                    Debug.Log("Correct shape selected: " + hit.collider.gameObject.name);
                    audioSource.PlayOneShot(correctClip);  // Play correct audio
                }
                else  // Incorrect answer
                {
                    Debug.Log("Incorrect shape selected: " + hit.collider.gameObject.name);
                    audioSource.PlayOneShot(incorrectClip);  // Play incorrect audio
                }
            }
        }
    }
}
