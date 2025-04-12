using UnityEngine;
using UnityEngine.UI;  // For working with UI elements

public class AudioButtonManager : MonoBehaviour
{
    public Button audioButton; // Button that will play audio
    public AudioSource audioSource; // AudioSource to play the audio
    public AudioClip audioClip; // Audio clip to play (e.g., "This is a sphere")

    void Start()
    {
        // Ensure the button has an onClick event that will trigger the PlayAudio method
        audioButton.onClick.AddListener(PlayAudio);
        
        // Ensure the audio clip is assigned
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();  // Automatically assign if missing
        
        // Assign the audio clip to the audio source
        if(audioClip != null)
            audioSource.clip = audioClip;
    }

    // This method will be triggered when the button is clicked
    void PlayAudio()
    {
        // Play the assigned audio clip
        audioSource.Play();
    }
}
