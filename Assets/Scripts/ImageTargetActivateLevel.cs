using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts
{
    class ImageTargetActivateLevel : MonoBehaviour,
        ITrackableEventHandler
    {
        public GameObject LevelGameObject;
        public String LevelName;


        private TrackableBehaviour _mTrackableBehaviour;

        void Start()
        {
            _mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (_mTrackableBehaviour)
            {
                _mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(
            TrackableBehaviour.Status previousStatus,
            TrackableBehaviour.Status newStatus)
        {
            if(previousStatus != newStatus)
            //Fornow just enables/disables an ui text that say if the target is tracked
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                LevelGameObject.SetActive(true);

                PlayerPrefs.SetString("CurrentLevel", LevelName);
                PlayerPrefs.Save();

            }
            else
            {
                LevelGameObject.SetActive(false);
                PlayerPrefs.SetString("CurrentLevel", "No Level");
                PlayerPrefs.Save();
                }
        }
        
    }
}
