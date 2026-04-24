using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// largely copied from labs
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Volume")]
    [SerializeField] public Slider VolumeSlider1;
    [SerializeField] public Slider VolumeSlider2;
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
    public AudioClip voice;

    public void OnValueSlider1Change() {
        if (VolumeSlider1.value == 0f) Mixer.SetFloat("volume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else Mixer.SetFloat("volume", 20 * Mathf.Log10(VolumeSlider1.value));
        //end copied code
        VolumeSlider2.value = VolumeSlider1.value;
    }
    public void OnValueSlider2Change() {
        if (VolumeSlider2.value == 0f) Mixer.SetFloat("volume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else Mixer.SetFloat("volume", 20 * Mathf.Log10(VolumeSlider2.value));
        //end copied code
        VolumeSlider1.value = VolumeSlider2.value;
    }
    public void OnMute() {
        VolumeSlider1.value = 0f;
        VolumeSlider2.value = 0f;
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
    public void PlayVoiceAudio(string inputAudio) {
        Debug.Log("InputAudio/" + inputAudio);
        Debug.Log(Resources.Load<AudioClip>("InputAudio/" + inputAudio));
        voiceSource.PlayOneShot(Resources.Load<AudioClip>("InputAudio/" + inputAudio));
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
