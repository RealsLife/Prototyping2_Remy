using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   
    public void LoadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

}
