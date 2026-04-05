using UnityEngine;
using UnityEngine.SceneManagement;
// script is only lightly modified from copied code
public class SceneLoader : MonoBehaviour
{
    private bool playing = true;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject MainMenu;
    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            print(playing);
            if (playing) {
                MainMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                playing = false;
            } else {   
                OptionsMenu.SetActive(false);
                MainMenu.SetActive(true);
                playing = true;
            }
        }
    }
    public void LoadScene (string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void OptionsMenuOn() {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void MainMenuOn() {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
