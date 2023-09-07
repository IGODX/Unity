using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	private SpriteRenderer renderer;
	private Animator animator;
	const string GOBLIN = "Goblin";
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		renderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		float right = Input.GetAxis("Horizontal");
		float up = Input.GetAxis("Vertical");
		if (right != 0 || up != 0)
		{
			var pos = transform.position;
			pos += Vector3.right * right * Time.deltaTime * 10;
			pos += Vector3.up * up * Time.deltaTime * 10;
			rigidbody.MovePosition(pos);
			animator.SetBool("Run", true);
		}
		else
		{
			animator.SetBool("Run", false);
		}
		if (right < 0)
		{
			renderer.flipX = true;
		}
		else if (right > 0)
		{
			renderer.flipX = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == GOBLIN)
		{
			RestartLevel();
		}
	}
	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	}
