using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter OtherTeleporter;
    private bool _ready = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable()
    {
        _ready = false;
    }

    void OnTriggerEnter(Collider other)
    {
        GolfPlayerController golfPlayer = other.gameObject.GetComponent<GolfPlayerController>();
        if (!golfPlayer || !_ready) return;
        OtherTeleporter.Disable();
        //print(OtherTeleporter.transform.position);
        //print(this.name);
        print(OtherTeleporter.gameObject.transform.rotation.eulerAngles.y);
        golfPlayer.GetComponent<Rigidbody>().velocity =
            Quaternion.AngleAxis(OtherTeleporter.gameObject.transform.rotation.eulerAngles.y, Vector3.up) * golfPlayer.GetComponent<Rigidbody>().velocity;
        golfPlayer.transform.position = OtherTeleporter.gameObject.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        GolfPlayerController golfPlayer = other.gameObject.GetComponent<GolfPlayerController>();
        if (!golfPlayer || _ready) return;
        _ready = true;
    }
}
