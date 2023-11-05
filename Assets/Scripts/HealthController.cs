using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float currentPlayerHealth = 100.0f;
    [SerializeField] private float maxPlayerHealth = 100.0f;
    [SerializeField] private int RegenRate = 1;
    private bool canRegen = false;
    [SerializeField] private Image BloodSplatterImage = null;
    [SerializeField] private Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;
    [SerializeField] private AudioClip hurtAudio = null;
    public AudioSource chokeAudio;
    bool playingChokeAudio;
    private AudioSource healthAudioSource;
    [SerializeField] private float healCooldown = 3.0f;
    [SerializeField] private float maxHealCooldown = 3.0f;
    [SerializeField] private bool startCooldown = false;
    public OxygenManager oxygenManager;
    public bool inTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        healthAudioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        Color splatterAlpha = BloodSplatterImage.color;
        splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        BloodSplatterImage.color = splatterAlpha;
    }
    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        healthAudioSource.PlayOneShot(hurtAudio);
        yield return new WaitForSeconds(hurtTimer);
        hurtImage.enabled = false;
    }
    public void TakeDamage()
    {
        if (currentPlayerHealth >= 0)
        {
            canRegen = false;
            StartCoroutine(HurtFlash());
            UpdateHealth();
            healCooldown = maxHealCooldown;
            startCooldown = true;
        }
    }
    private void Update()
    {
        if (startCooldown) 
        {
            healCooldown -= Time.deltaTime;
            if (healCooldown <= 0)
            {
                canRegen = true;
                startCooldown= false;
            }
        }
        if (oxygenManager.NoOxygen && !inTutorial)
        {
            canRegen = false;
            currentPlayerHealth = currentPlayerHealth - .1f * Difficulty.difficulty;
            if (!playingChokeAudio)
            {
                playingChokeAudio = true;
                chokeAudio.Play();
            }
        }
        else
        {
            canRegen = true;
            playingChokeAudio = false;
            chokeAudio.Stop();
        }
        if (canRegen)
        {
            if (currentPlayerHealth <= maxPlayerHealth - 0.01)
            {
                currentPlayerHealth += Time.deltaTime * RegenRate;
                UpdateHealth();
            }
            else
            {
                currentPlayerHealth = maxPlayerHealth;
                healCooldown = maxHealCooldown;
                canRegen= false;
            }
        }
        if (currentPlayerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
