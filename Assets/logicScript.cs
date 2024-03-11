using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public Image medalImage;
    public Text medalText;
    public Sprite bronzeMedalSprite;
    public Sprite silverMedalSprite;
    public Sprite goldMedalSprite;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    public AudioClip audioClip3;
    private AudioSource audioSource3;

    public Image pauseImg;

    private bool gameOverV = false;
    private bool gamePaused = false;

    private void Start()
    {
        // Create GameObjects to hold the audio sources
        GameObject audioObject1 = new GameObject("AudioSource1");
        GameObject audioObject2 = new GameObject("AudioSource2");
        GameObject audioObject3 = new GameObject("AudioSource3");

        // Attach AudioSources to the GameObjects
        audioSource1 = audioObject1.AddComponent<AudioSource>();
        audioSource2 = audioObject2.AddComponent<AudioSource>();
        audioSource3 = audioObject3.AddComponent<AudioSource>();

        // Assign audio clips to the AudioSources
        audioSource1.clip = audioClip1;
        audioSource2.clip = audioClip2;
        audioSource3.clip = audioClip3;

        // Set loop to true for both AudioSources
        audioSource1.loop = true;
        audioSource2.loop = true;
        audioSource3.loop = false;

        // Play audioClip1
        audioSource1.Play();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverV = true;
        gameOverScreen.SetActive(true);
        if (playerScore < 6)
        {
            medalImage.sprite = bronzeMedalSprite;
            medalText.text = "Yay, BRONZE !";
        }
        else if (playerScore < 11)
        {
            medalImage.sprite = silverMedalSprite;
            medalText.text = "Yayy, SILVER !!";
        }
        else
        {
            medalImage.sprite = goldMedalSprite;
            medalText.text = "Yayyy, GOLD !!!";
        }
        audioSource3.PlayOneShot(audioClip3);
        StartCoroutine(TurnOffAudioAfterDelay(4f));
    }

    private IEnumerator TurnOffAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource1.Stop();
        audioSource2.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (gameOverV) return;
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0 : 1;

        if (gamePaused)
        {
            audioSource1.Pause();
            audioSource2.Play();
            pauseImg.gameObject.SetActive(true);
        }
        else
        {
            audioSource1.Play();
            audioSource2.Pause();
            pauseImg.gameObject.SetActive(false);
        }
    }
}
