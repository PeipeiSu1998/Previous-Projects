//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Handles the spawning and returning of the ItemPackage
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.Events;
#if UNITY_EDITOR
#endif

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class ItemPackageSpawner : MonoBehaviourPunCallbacks
	{
		public ItemPackage itemPackage
		{
			get
			{
				return _itemPackage;
			}
			set
			{
				CreatePreviewObject();
			}
		}

		public ItemPackage _itemPackage;

		public bool useItemPackagePreview = true;
        private bool useFadedPreview = false;
		private GameObject previewObject;

		[EnumFlags]
		public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;

		private GameObject spawnedItem;
		private bool itemIsSpawned = false;

		public UnityEvent dropEvent;


		//-------------------------------------------------
		private void CreatePreviewObject()
		{
			if ( !useItemPackagePreview )
			{
				return;
			}

			ClearPreview();

			if ( useItemPackagePreview )
			{
				if ( itemPackage == null )
				{
					return;
				}

				if ( useFadedPreview == false ) // if we don't have a spawned item out there, use the regular preview
				{
					if ( itemPackage.previewPrefab != null )
					{
						previewObject = Instantiate( itemPackage.previewPrefab, transform.position, Quaternion.identity ) as GameObject;
						previewObject.transform.parent = transform;
						previewObject.transform.localRotation = Quaternion.identity;
					}
				}
				else // there's a spawned item out there. Use the faded preview
				{
					if ( itemPackage.fadedPreviewPrefab != null )
					{
						previewObject = Instantiate( itemPackage.fadedPreviewPrefab, transform.position, Quaternion.identity ) as GameObject;
						previewObject.transform.parent = transform;
						previewObject.transform.localRotation = Quaternion.identity;
					}
				}
			}
		}


		//-------------------------------------------------
		void Start()
		{
			VerifyItemPackage();
			if (photonView.IsMine)
			{
				SpawnAndAttachObject( GetComponent<Hand>(), GrabTypes.Scripted );
			}
		}


		//-------------------------------------------------
		private void VerifyItemPackage()
		{
			if ( itemPackage == null )
			{
				ItemPackageNotValid();
			}

			if ( itemPackage.itemPrefab == null )
			{
				ItemPackageNotValid();
			}
		}


		//-------------------------------------------------
		private void ItemPackageNotValid()
		{
			Debug.LogError("<b>[SteamVR Interaction]</b> ItemPackage assigned to " + gameObject.name + " is not valid. Destroying this game object.", this);
			Destroy( gameObject );
		}


		//-------------------------------------------------
		private void ClearPreview()
		{
			foreach ( Transform child in transform )
			{
				if ( Time.time > 0 )
				{
					GameObject.Destroy( child.gameObject );
				}
				else
				{
					GameObject.DestroyImmediate( child.gameObject );
				}
			}
		}


		//-------------------------------------------------
		void Update()
		{
			if ( ( itemIsSpawned == true ) && ( spawnedItem == null ) )
			{
				itemIsSpawned = false;
				useFadedPreview = false;
				dropEvent.Invoke();
				CreatePreviewObject();
			}
		}


		//-------------------------------------------------
		private void SpawnAndAttachObject( Hand hand, GrabTypes grabType )
		{
			spawnedItem = PhotonNetwork.
						  Instantiate(itemPackage.itemPrefab.name,
						              Vector3.zero,
									  Quaternion.identity);
			hand.AttachObject( spawnedItem, grabType, attachmentFlags );

			StartCoroutine(WaitBeforeSpawningTheArrowHand(hand, grabType));
		}

		private IEnumerator WaitBeforeSpawningTheArrowHand(Hand hand,
														   GrabTypes grabType)
		{
			yield return new WaitUntil(() => hand.otherHand.isActive);
			
			if ( ( itemPackage.otherHandItemPrefab != null )
				&& 
				 ( hand.otherHand.isActive ) )
			{
				GameObject otherHandObjectToAttach = 
				GameObject.Instantiate(itemPackage.otherHandItemPrefab);
				hand.otherHand.AttachObject(otherHandObjectToAttach,
											grabType,
											attachmentFlags);
			}
			itemIsSpawned = true;
		}
	}
}
