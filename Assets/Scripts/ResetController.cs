using UnityEngine;

namespace Assets.Scripts
{
    public class ResetController : MonoBehaviour {

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
        void OnTriggerEnter(Collider other)
        {
            GolfPlayerController golfPlayer = other.gameObject.GetComponent<GolfPlayerController>();
            if (!golfPlayer) return;
            golfPlayer.ResetGame();
            print("You fell down you noob >:|");
        }
    }
}
