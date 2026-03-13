using UnityEngine;
using UnityEngine.SceneManagement;
// script is only lightly modified from copied code
public class SceneLoader : MonoBehaviour
{
    private bool playing = true;
    public static SceneLoader Instance;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject MainMenu;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (playing) OptionsMenuOn();
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
    public void BackClick() {
        if (OptionsMenu.activeSelf) {
            OptionsMenu.SetActive(false);
        } else {
            MainMenuOn();
        }
    }
}
