using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadShapeSelectionScene()
    {
        SceneManager.LoadScene("ShapeSelectionScene"); // Ensure this matches the scene name exactly
    }
}
