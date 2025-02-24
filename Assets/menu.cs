using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Playgame(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID);
    }

}
