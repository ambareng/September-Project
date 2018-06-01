using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToPlayer : MonoBehaviour {
	public static float ToTarget;
	public float Target;

	void Update () {
		RaycastHit Hit;

		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit)) { // Will "Cast A Ray" to an object from THIS object and will measure it's distance.
			ToTarget = Hit.distance; // In other words, will measure the distance of THIS object to an object it is currently looking/pointing/facing at directly.
			Target = ToTarget;
		}
	}
}