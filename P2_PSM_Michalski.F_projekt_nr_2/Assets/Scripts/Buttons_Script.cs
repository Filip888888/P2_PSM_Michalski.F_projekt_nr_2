using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_Script : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
