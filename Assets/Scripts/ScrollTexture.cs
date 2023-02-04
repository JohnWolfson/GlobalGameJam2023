using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {

	public float ScrollSpeed = -0.01f;
	public float XScrollSpeed = 0.01f;
	public bool scrollDetail;
	public float DetailScrollSpeed = 0.01f;
	public float XDetailScrollSpeed = 0.01f;
	public int materialSlot = 0;
	MeshRenderer renderer;
	float time = 0f;
	float timeX = 0f;
	float timeDetail = 0f;
	float timeDetailX = 0f;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		renderer.materials[materialSlot].SetTextureOffset ("_MainTex", new Vector2 (timeX, time));

		if(scrollDetail){
			renderer.materials[materialSlot].SetTextureOffset ("_DetailAlbedoMap", new Vector2 (timeDetailX, timeDetail));
		}

		time += Time.deltaTime * ScrollSpeed;
		timeX += Time.deltaTime * XScrollSpeed;
		timeDetail += Time.deltaTime * DetailScrollSpeed;
		timeDetailX += Time.deltaTime * XDetailScrollSpeed;

		if (time >= 1) {
			time = 0;
		}

		if (timeX >= 1) {
			timeX = 0;
		}

		if (timeDetail >= 1) {
			timeDetail = 0;
		}
		
		if (timeDetailX >= 1) {
			timeDetailX = 0;
		}
	}
}
