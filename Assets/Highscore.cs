using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

public Text score; 
public Text highScore;


void Start (){

    highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
}

public void RollDice()
    {

       int number =  Random.Range(1,7);
        score.text = number.ToString();

        if(number > PlayerPrefs.GetInt("Highscore",0)){

            PlayerPrefs.SetInt("Highscore", number);
            highScore.text = number.ToString();
        }
     
    }
}
