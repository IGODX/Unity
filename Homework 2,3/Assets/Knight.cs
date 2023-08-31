using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
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
		}
	}
}
