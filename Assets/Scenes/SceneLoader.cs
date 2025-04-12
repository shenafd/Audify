using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneLoader : MonoBehaviour
{
    public void LoadShapeSelectionScene()
    {
        SceneManager.LoadScene("ShapeSelectionScene"); // Ensure this matches the scene name exactly
    }

    public void LoadARdrawingScene()
    {
        SceneManager.LoadScene("ARdrawingScene"); // Replace with your scene name
    }

        public void LoadHomeScreen()
    {
        SceneManager.LoadScene("HomeScreen"); // Replace "HomeScreen" with the name of your home scene
    }

}
