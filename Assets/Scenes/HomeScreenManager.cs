using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
    public void LoadGame1()
    {
        SceneManager.LoadScene("ARscene");
    }

    public void LoadGame2()
    {
        Debug.Log("Game 2 Clicked! Add Scene Here.");
    }

    public void LoadGame3()
    {
        Debug.Log("Game 3 Clicked! Add Scene Here.");
    }
}
