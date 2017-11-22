using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {
    public Transform Point1;
    public Transform Point2;
    public GameObject Obstacle;
    private float movingTime;
    public float speed;
    private float distance;
    private float currentTime;
    private float direction = 1;
    // Use this for initialization

    void Start () {
        distance = (Point1.position - Point2.position).magnitude;
        movingTime = distance / speed;
        currentTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += (direction * Time.deltaTime);
        if (currentTime > movingTime || currentTime < 0 )
            direction = -direction;

        float perct = currentTime/movingTime;        
        Obstacle.transform.position = Vector3.Lerp(Point1.position, Point2.position, perct);


    }
}
