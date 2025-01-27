﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatingTheSun : MonoBehaviour
{

	//　1秒間の回転角度
	[SerializeField]
	private float rotateSpeed = 0.25f;
	//　0時の角度
	[SerializeField]
	private Vector3 rot = new Vector3(270f, 330f, 0f);

	void Start()
	{
		
		transform.localRotation = Quaternion.Euler(66f,30f,25f);
		//　太陽を傾ける
		var rotX = transform.localEulerAngles.x;
		//　マイナスの値だったら360を足して0～360の間に補正
		if (rotX < 0)
		{
			rotX += 360f;
		}
		//　太陽の角度を設定
		transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}

	// Update is called once per frame
	void Update()
	{
		//　徐々に回転させる、X軸を反対方向に回転
		transform.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
	}
}