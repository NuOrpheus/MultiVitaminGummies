using UnityEngine;
using UnityEngine.SceneManagement;
// smaller version of original sceneloader from labs
public class SimpleSceneLoader : MonoBehaviour
{
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
