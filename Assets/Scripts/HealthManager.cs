using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public Image deathImage;
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f);     // The colour the damageImage is set to, to flash.
	public Color deathColour = new Color(0f,0f,0f);

	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	public GameObject hud;

	public bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake ()
	{
		playerAudio = GetComponent <AudioSource> ();

		// Set the initial health of the player.
		currentHealth = startingHealth;
	}


	void Update ()
	{
		// If the player has just been damaged...
		if(damaged && !isDead)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		// Reset the damaged flag.
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}


	public void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		//deathImage.color = Color.Lerp (Color.clear, deathColour, 3);
		deathImage.color = deathColour;
		hud.SetActive (false);
		StartCoroutine (restartGame());



		AudioSource[] audios = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource aud in audios) {
			aud.volume = 0;
		}

		playerAudio.volume = 1;
		playerAudio.Play ();

	}       

	void OnTriggerEnter (Collider other)  {
        if (other.tag == "stone") {
            TakeDamage(0);
        }

        

		//if (other.tag == "lava") {
		//	Death ();
		//}
	}

	IEnumerator restartGame() {
		yield return new WaitForSeconds (20);
		Application.LoadLevel (Application.loadedLevel);
	}
}


