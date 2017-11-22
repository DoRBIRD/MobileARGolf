using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour {
    public Transform Pivot;
    public Transform StartDir;
    public Transform EndDir;
    public GameObject Platform;
    public float RotationSpeed;

    private Vector3 Direction1;
    private Vector3 Direction2;
    private Vector3 currentTargetDir ;
    private float turnaroundThreshhold = 0.01f;



    // Use this for initialization
    void Start ()
    {
        Direction1 = (EndDir.position - Pivot.position).normalized;
        Direction2 = (StartDir.position - Pivot.position).normalized;
        transform.rotation = Quaternion.LookRotation(Direction1);
        currentTargetDir = Direction2;

    }
   
    // Update is called once per frame
    void Update () {
        if ((transform.forward - Direction1).magnitude < turnaroundThreshhold)
            currentTargetDir = Direction2;
        if ((transform.forward - Direction2).magnitude < turnaroundThreshhold)
            currentTargetDir = Direction1;
        float step = RotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, currentTargetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
