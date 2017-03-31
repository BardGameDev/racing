using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropping : MonoBehaviour
{
	public float delayTime;
  private Vector3 pointB;


    // Use this for initialization
    IEnumerator Start()
    {
		yield return new WaitForSeconds(delayTime);
		pointB = new Vector3(transform.position.x, transform.position.y - 5,transform.position.z);
    Vector3 pointA = transform.position;
		while (true){
			yield return StartCoroutine(MoveObjectDown(transform, pointA, pointB, 3));
			yield return StartCoroutine(MoveObjectUp(transform, pointB, pointA, 3));
		}
	}

	// Update is called once per frame
	IEnumerator MoveObjectDown (Transform thisTransform, Vector3 startpos, Vector3 endpos, float time) {
		float i = 0.0f;
		float rate = 5.0f/time;
		while (i< 1.0f){
			i += Time.deltaTime*rate;
			thisTransform.position = Vector3.Lerp(startpos, endpos, i);
			yield return null;
		}
	}

	IEnumerator MoveObjectUp (Transform thisTransform, Vector3 startpos, Vector3 endpos, float time) {
		float i = 0.0f;
		float rate = 2.0f/time;
		while (i< 1.0f){
			i += Time.deltaTime*rate;
			thisTransform.position = Vector3.Lerp(startpos, endpos, i);
			yield return null;
		}
	}
}
