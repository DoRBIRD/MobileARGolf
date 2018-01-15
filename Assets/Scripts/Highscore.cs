using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Highscore : MonoBehaviour
    {
        public Text txtLevel;
        public Text txtScore;
        public static int score;
        public Text txtHighscore;
        public static int highscore;
        private GolfPlayerController _golfPlayer;

        void Start()
        {
            score = 0;
        }

        void Update()
        {
            string PLAYER = PlayerPrefs.GetString("Player_name", "Jonas");
            string LEVEL = PlayerPrefs.GetString("CurrentLevel", "No Level");
            string key = "highscore_" + PLAYER + "_LEVEL_" + LEVEL;

            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if(go)
                _golfPlayer = go.GetComponent<GolfPlayerController>();

            txtScore.text = "Score: " + _golfPlayer.GetBlows();

            txtHighscore.text = PLAYER + " Highscore: " + PlayerPrefs.GetInt(key);
            txtLevel.text = LEVEL;
        }
    }
}
