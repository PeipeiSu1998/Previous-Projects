//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Target that sends events when hit by an arrow
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Photon.Pun;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class ArcheryTarget : MonoBehaviourPunCallbacks
	{
		public UnityEvent onTakeDamage;

		public bool onceOnly = false;
		public Transform targetCenter;

		public Transform baseTransform;
		public Transform fallenDownTransform;
		public float fallTime = 0.5f;

		const float targetRadius = 0.25f;

		private bool targetEnabled = true;


		//-------------------------------------------------
		
		private void ApplyDamageFromOwnArrow()
		{
			if (!photonView.IsMine)
			{
				OnDamageTaken();
			}	
		}
		
		private void ApplyDamageFromOpponentsArrow()
		{
			if (photonView.IsMine)
			{
				OnDamageTaken();
			}
		}


		//-------------------------------------------------
		private void FireExposure()
		{
			OnDamageTaken();
		}


		//-------------------------------------------------
		private void OnDamageTaken()
		{
			Debug.Log("OnDamageTaken");
			if ( targetEnabled )
			{
				onTakeDamage.Invoke();
				StartCoroutine( this.FallDown() );

				if ( onceOnly )
				{
					targetEnabled = false;
				}
			}
		}


		//-------------------------------------------------
		private IEnumerator FallDown()
		{
			Debug.Log("FallDown");
			if ( baseTransform )
			{
				Quaternion startingRot = baseTransform.rotation;

				float startTime = Time.time;
				float rotLerp = 0f;

				while ( rotLerp < 1 )
				{
					rotLerp = Util.RemapNumberClamped( Time.time, startTime, startTime + fallTime, 0f, 1f );
					baseTransform.rotation = Quaternion.Lerp( startingRot, fallenDownTransform.rotation, rotLerp );
					yield return null;
				}
			}

			yield return null;
		}
	}
}
