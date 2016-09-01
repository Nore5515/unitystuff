using UnityEngine;
using System.Collections;

public class relativeMovement : MonoBehaviour
{

	public float pushForce = 1000.0f;

	public ControllerColliderHit _contact;

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		_contact = hit;

		Rigidbody body = hit.collider.attachedRigidbody;

		if (body != null && !body.isKinematic) {
			body.velocity = hit.moveDirection * pushForce;
		}

	}

}
