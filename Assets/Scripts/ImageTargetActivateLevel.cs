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
        public GameObject IsTargetTrackedUiText;

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
                IsTargetTrackedUiText.SetActive(false);
            }
            else
            {
                IsTargetTrackedUiText.SetActive(true);
            }
        }
        
    }
}
