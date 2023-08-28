using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	public LayerMask groundLayer;
	private bool isGrounded;
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		groundLayer = LayerMask.GetMask("Ground", "Player");
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
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, groundLayer))
				pos += Vector3.up * up * Time.deltaTime * 10;
			rigidbody.MovePosition(pos);
		}
	}
}
