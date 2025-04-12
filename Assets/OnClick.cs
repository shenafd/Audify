using UnityEngine;

public class ShowHideObject : MonoBehaviour
{
    public GameObject objectToToggle; // Drag your Sphere here in the Inspector

    public void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
