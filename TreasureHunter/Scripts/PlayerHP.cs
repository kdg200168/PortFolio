using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHP : MonoBehaviour
{
	
	//　現在のHP
	public   float playerhp = 10;
	PlayerController pc;
	public AudioClip sound1;
	private AudioSource audioSource;

	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
		pc = GetComponent<PlayerController>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	void Update()
    {
		if (playerhp < 0)
		{
			playerhp += 0.5f * Time.deltaTime;
		}
		if(playerhp > 10)

		{
			playerhp = 10;
		}

	}
	public void TakeDamage(int damage)
	{
		playerhp -= damage;
		if (audioSource.isPlaying == false)
		{
			audioSource.PlayOneShot(sound1);
		}
		if (playerhp <= 0)
        {
			pc.GetComponent<PlayerController>().dead = true;
			animator.SetBool("dead", true);
			Invoke("GoToGameOver", 5.0f);

		}
	}
	void GoToGameOver()
	{
		SceneManager.LoadScene("GameOverScene");
	}
}
