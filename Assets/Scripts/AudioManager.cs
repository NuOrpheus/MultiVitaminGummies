using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// largely copied from labs
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Volume")]
    [SerializeField] public Slider VolumeSlider;
    [SerializeField] private AudioMixer Mixer;
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;
    [Header("Audio Clips")]
    public AudioClip menuMusic;
    public AudioClip backgroundMusic;
    public AudioClip clickSfx;
    public AudioClip wrongClickSfx;
    public void OnValueSliderChange() {
        if (VolumeSlider.value == 0f) Mixer.SetFloat("volume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else Mixer.SetFloat("volume", 20 * Mathf.Log10(VolumeSlider.value));
        //end copied code
    }
    public void OnMute() {
        VolumeSlider.value = 0f;
    }
    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    private void Start()
    {   
        if (backgroundMusic != null && musicSource != null){
            try {
                if (SceneManager.GetActiveScene().buildIndex == 0) {
                    musicSource.clip = menuMusic;
                } else {
                    musicSource.clip = backgroundMusic;
                }
            } catch {
                musicSource.clip = backgroundMusic;
            }
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlayButtonSfx() {
        sfxSource.PlayOneShot(clickSfx);
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
