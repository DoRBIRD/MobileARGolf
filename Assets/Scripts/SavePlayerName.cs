using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class SavePlayerName: MonoBehaviour 
    {
        public InputField NameInput;


        void Start()
        {
            NameInput.text = PlayerPrefs.GetString("Player_name", "Anon");
        }



        public void SavePlayerNameToPrefs()
        {
            if (NameInput.text != null)
                PlayerPrefs.SetString("Player_name", NameInput.text);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
        }
    }
}
