using UnityEngine;

namespace Assets.Scripts
{
    public class GoalController : MonoBehaviour {

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
            print("Yay you won with " + golfPlayer.GetBlows() + " Blows! :D");
            golfPlayer.ResetGame();
        }
    }
}
