using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
	[SerializeField]
	public Animator Platform;
	[SerializeField]
	public Animator AnimatorCTRL;
	[SerializeField]
	private Rigidbody2D myRigidbody;

	private void Update()
	{
		AnimatorCTRL.SetFloat ("VerticalSPD", myRigidbody.velocity.y);

	}

		
}
