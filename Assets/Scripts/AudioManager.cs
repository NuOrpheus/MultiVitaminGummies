using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
// largely copied from labs
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Volume")]
    [SerializeField] private Slider SfxSlider1;
    [SerializeField] private Slider MusicSlider1;
    [SerializeField] private Slider SfxSlider2;
    [SerializeField] private Slider MusicSlider2;
    //[SerializeField] private AudioMixer MasterMixer;
    [SerializeField] private AudioMixer SfxMixer;
    [SerializeField] private AudioMixer MusicMixer;
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;
    [Header("Audio Clips")]
    public AudioClip menuMusic;
    //public AudioClip backgroundMusic;
    public AudioClip clickSfx;
    public AudioClip voice;
    public AudioClip sliderSfx;

    public void OnValueSfxSlider1Change() {
        if (SfxSlider1.value == 0f) SfxMixer.SetFloat("SfxVolume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else SfxMixer.SetFloat("SfxVolume", 20 * Mathf.Log10(SfxSlider1.value));
        //end copied code
        MusicSlider2.value = MusicSlider1.value;
    }
    public void OnValueSfxSlider2Change() {
        if (SfxSlider2.value == 0f) SfxMixer.SetFloat("SfxVolume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else SfxMixer.SetFloat("SfxVolume", 20 * Mathf.Log10(SfxSlider2.value));
        //end copied code
        MusicSlider1.value = MusicSlider2.value;
    }
    public void OnValueMusicSlider1Change() {
        if (MusicSlider1.value == 0f) MusicMixer.SetFloat("MusicVolume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else MusicMixer.SetFloat("MusicVolume", 20 * Mathf.Log10(MusicSlider1.value));
        //end copied code
        SfxSlider2.value = SfxSlider1.value;
    }
    public void OnValueMusicSlider2Change() {
        if (MusicSlider2.value == 0f) MusicMixer.SetFloat("MusicVolume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else MusicMixer.SetFloat("MusicVolume", 20 * Mathf.Log10(MusicSlider2.value));
        //end copied code
        SfxSlider1.value = SfxSlider2.value;
    }

    private void Start() {
        sfxSource.clip = sliderSfx;
        if (menuMusic != null && musicSource != null){
            musicSource.clip = menuMusic;
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
    public void PlaySliderSfx() {
        if (!sfxSource.isPlaying) sfxSource.Play();
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
