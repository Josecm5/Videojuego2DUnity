﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

	public Transform target;

	Vector3 velocity = Vector3.zero;

	public float smoothTime = .15f;

	public bool YMaxEnabled = false;
	public float YMaxValue = 0;

	public bool YMinEnabled = false;
	public float YMinValue = 0;

	public bool XMaxEnabled = false;
	public float XMaxValue = 0;

	public bool XMinEnabled = false;
	public float XMinValue = 0;

	void FixedUpdate()
	{
		Vector3 targetPos = target.position;

		//Vertical
		if (YMinEnabled && YMaxEnabled)
			targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);

		else if (YMinEnabled)
			targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
		
		else if (YMaxEnabled)
			targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);

		//horizontal
		if (XMinEnabled && XMaxEnabled)
			targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
		
		else if (XMinEnabled)
			targetPos.x = Mathf.Clamp(target.position.x, XMaxValue, target.position.x);
		
		else if (XMaxEnabled)
			targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
			
		targetPos.z = transform.position.z;

		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
	}
}
