using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
	public float seconds;
	public float timer;
	public GameObject endPos;
	public Vector3 Point;
	public Vector3 Difference;
	public Vector3 start;
	public float percent;
	public bool moving;
	void Start()
	{
		
		start = transform.position;
		Point = endPos.transform.position;
		Difference = Point - start;
	}
	void Update()
	{
		if (moving == true)
		{
			if (timer <= seconds)
			{
				timer += Time.deltaTime;
				percent = timer / seconds;
				transform.position = start + Difference * percent;
			}
		}
	}
}
