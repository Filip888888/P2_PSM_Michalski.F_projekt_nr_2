using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float count = 14.6f;
    public int victims_alive = 2;
    public int kill_count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;

        if (count <= 0 && SceneManager.GetActiveScene().name == "cutscene")
        {
            SceneManager.LoadScene("LvL_2", LoadSceneMode.Single);
        }else if(SceneManager.GetActiveScene().name == "LvL_2" && victims_alive == 0)
        {
            SceneManager.LoadScene("cutscene", LoadSceneMode.Single);
        }else if(SceneManager.GetActiveScene().name == "LvL_2" && kill_count == 11)
        {
            SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
        }


    }
}
