using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChangeInputMode : MonoBehaviour {

        private GolfPlayerController _golfPlayer;
	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go)
                _golfPlayer = go.GetComponent<GolfPlayerController>();
        }


        public void changeInputMode()
        {
            _golfPlayer.ToggleInputMode();
        }
    }
}
