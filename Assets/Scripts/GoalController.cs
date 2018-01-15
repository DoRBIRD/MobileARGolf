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
            StoreHighscore(golfPlayer.GetBlows());
            print("Yay you won with " + golfPlayer.GetBlows() + " Blows! :D");
            golfPlayer.ResetGame();
           
        }

        void StoreHighscore(int newHighscore)
        {
            string PLAYER = PlayerPrefs.GetString("Player_name", "Jonas");
            string LEVEL = PlayerPrefs.GetString("CurrentLevel", "No Level");
            string key = "highscore_" + PLAYER+"_LEVEL_"+ LEVEL;
            print(PLAYER +" just won with score: " + newHighscore);
            int oldHighscore = PlayerPrefs.GetInt(key, int.MaxValue);
            if (newHighscore < oldHighscore)
            {
                PlayerPrefs.SetInt(key, newHighscore);
                PlayerPrefs.Save();
            }
        }
    }
}
