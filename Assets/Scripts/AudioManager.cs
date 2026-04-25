using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
// largely copied from labs
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Volume")]
    [SerializeField] private Slider VolumeSlider1;
    [SerializeField] private Slider VolumeSlider2;
    //[SerializeField] private AudioMixer MasterMixer;
    //[SerializeField] public AudioMixer MusicMixer;
    [SerializeField] public AudioMixer MusicMixer;
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;
    [Header("Audio Clips")]
    public AudioClip menuMusic;
    //public AudioClip backgroundMusic;
    public AudioClip clickSfx;
    public AudioClip voice;

    public void OnValueSlider1Change() {
        if (VolumeSlider1.value == 0f) MusicMixer.SetFloat("Volume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else MusicMixer.SetFloat("Volume", 20 * Mathf.Log10(VolumeSlider1.value));
        //end copied code
        //VolumeSlider2.value = VolumeSlider1.value;
    }
    public void OnValueSlider2Change() {
        if (VolumeSlider2.value == 0f) MusicMixer.SetFloat("volume", -80f);
        // start copied code https://discussions.unity.com/t/how-to-calculate-db-correct/712114
        else MusicMixer.SetFloat("volume", 20 * Mathf.Log10(VolumeSlider2.value));
        //end copied code
        //VolumeSlider1.value = VolumeSlider2.value;
    }
    public void OnMute() {
        VolumeSlider1.value = 0f;
        VolumeSlider2.value = 0f;
    }
    private void Start()
    {  
        MusicMixer.SetFloat("volume", 0.5f);
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
