using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Highscore : MonoBehaviour
    {
        public Text txtScore;
        public static int score;
        public Text txtHighscore;
        public static int highscore;
        public GolfPlayerController GolfPlayer;

        void Start()
        {
            score = 0;
        }

        void Update()
        {
            string PLAYER = PlayerPrefs.GetString("Player_name","Jonas");
            string LEVEL = "level1";
            string key = "highscore_" + PLAYER + "_LEVEL_" + LEVEL;
            txtScore.text = "Score: " + GolfPlayer.GetBlows();
            txtHighscore.text = PLAYER + " Highscore: " + PlayerPrefs.GetInt(key);
        }
    }
}
