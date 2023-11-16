using UnityEngine;
using System.Collections;

namespace Vuforia
{
    public class AEPImageTrackerBase : MonoBehaviour, ITrackableEventHandler
    {
        public bool testing;
        public string loaderName;
        public string playerPrefsValue;
        public string assetBundle;
        public string asset;

        public bool allowTracking { get; set; }
        public TrackableBehaviour mTrackableBehaviour { get; set; }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                onScan(true);
            }
            else
            {
                onScan(false);
            }
        }

        public virtual void onScan(bool track)
        {

        }

        public virtual void animate(bool animate)
        {

        }
    }
}