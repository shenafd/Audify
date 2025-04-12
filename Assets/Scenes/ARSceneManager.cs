using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneManager : MonoBehaviour
{
    public void LoadARDrawingScene()
    {
        SceneManager.LoadScene("ARDrawingScene");
    }
}
