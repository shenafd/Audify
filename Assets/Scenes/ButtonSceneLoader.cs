using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes

public class ButtonSceneLoader : MonoBehaviour
{
    // Method to load the ShapeSelectionScene
    public void LoadShapeSelectionScene()
    {
        SceneManager.LoadScene("ShapeSelectionScene"); // Ensure this matches the name of your scene exactly
    }
}
