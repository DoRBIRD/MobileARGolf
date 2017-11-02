using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIBlowCounter : MonoBehaviour
    {
        public GolfPlayerController GolfPlayer;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            GetComponent<Text>().text = "Blows: " + GolfPlayer.GetBlows();

        }
    }
}
