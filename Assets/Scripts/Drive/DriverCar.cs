using UnityEngine;
using System.Collections;

public class DriverCar : MonoBehaviour
{

	private WheelCollider[] wheels;

	public float maxAngle = 30;
	public float maxTorque = 300;

	public GameObject _light;
	public GameObject _FrontLight;
	
	public void Start()
	{
		wheels = GetComponentsInChildren<WheelCollider>();

		_light.SetActive(false);
		_FrontLight.SetActive(false);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			_light.SetActive(true);
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			_light.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			_FrontLight.SetActive(!_FrontLight.activeSelf);
		}

		float angle = maxAngle * Input.GetAxis("Horizontal");
		float torque = maxTorque * Input.GetAxis("Vertical");

		foreach (WheelCollider wheel in wheels)
		{
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = torque;
		}
		
	}
	
}
