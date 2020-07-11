using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public GameObject target;
	public float yMax;
	public float xMin;
	public float xMax;
	public float yMin;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp(target.transform.position.x, xMin, xMax), Mathf.Clamp(target.transform.position.y, yMin, yMax), transform.position.z);
	}
}

