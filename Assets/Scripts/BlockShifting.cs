using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShifting : MonoBehaviour
{
	public float delayTime;
	public float shiftingSpeed;
  private Vector3 pointB;


    // Use this for initialization
    IEnumerator Start()
    {
		yield return new WaitForSeconds(delayTime);
		pointB = new Vector3(transform.position.x - 12, transform.position.y,transform.position.z);
    Vector3 pointA = transform.position;
		while (true){
			yield return StartCoroutine(MoveObjectDown(transform, pointA, pointB, 3));
			yield return StartCoroutine(MoveObjectUp(transform, pointB, pointA, 3));
		}
	}

	// Update is called once per frame
	IEnumerator MoveObjectDown (Transform thisTransform, Vector3 startpos, Vector3 endpos, float time) {
		float i = 0.0f;
		float rate = shiftingSpeed/time;
		while (i< 1.0f){
			i += Time.deltaTime*rate;
			thisTransform.position = Vector3.Lerp(startpos, endpos, i);
			yield return null;
		}
	}

	IEnumerator MoveObjectUp (Transform thisTransform, Vector3 startpos, Vector3 endpos, float time) {
		float i = 0.0f;
		float rate = shiftingSpeed/time;
		while (i< 1.0f){
			i += Time.deltaTime*rate;
			thisTransform.position = Vector3.Lerp(startpos, endpos, i);
			yield return null;
		}
	}
}
