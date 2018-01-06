using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraGolfClub : MonoBehaviour {

    public GameObject GolfBall;
    public GameObject AimingRay;
    public GameObject AimingDirection;
    private Vector3 AimingVector;
    private static readonly float force = 0.1f;

	// Use this for initialization
	void Start () {
		//
	}
	
	// Update is called once per frame
	void Update () {
        AimingVector = GolfBall.transform.position - transform.position;
        //AimingRay.transform.LookAt(GolfBall.transform);
        //AimingRay.transform.localScale = new Vector3(1, AimingVector.magnitude, 1);
        var y = Mathf.Abs(AimingVector.y);
        AimingVector.y = 0;
        AimingVector *= y * force;
        //print(AimingVector);
        var aimAngle = Vector3.Angle(AimingVector, Vector3.forward);
        //print(aimAngle);
        AimingDirection.transform.eulerAngles = new Vector3(90, aimAngle + 90, 0);
        AimingDirection.transform.position = GolfBall.transform.position + AimingVector * 2;
        AimingDirection.transform.localPosition = new Vector3(0, 4, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            GolfBall.GetComponent<Rigidbody>().AddForce(AimingVector);
        }
	}
}
