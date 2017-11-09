using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotResetOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }
    
	// Update is called once per frame
	void Update () {
		   
	}
}
