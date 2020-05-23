using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
	public class ShootingText : MonoBehaviour {

  
		private void Start() {
				gameObject.SetActive(false);
            if (Arrow.shootTextEvent == null) Arrow.shootTextEvent = new UnityEngine.Events.UnityEvent();
            Arrow.shootTextEvent.AddListener(CheckBalloon);
		}

		public void CheckBalloon(){
                   gameObject.SetActive(true);
			}
	}
}
