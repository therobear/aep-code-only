//MD5Hash:923be7540e62bef80a0a165868e8168a;
using Vuforia;
using UnityEngine;
using System;
using System.Collections;


namespace Vuforia
{
	public class OnTrack_AEPLogo : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		public Vuforia.StateManager smStateManager = null;


		void Awake()
		{
			MenuController.HideInfoGraphics();
		}
		void Start()
		{
			mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
			smStateManager = Vuforia.TrackerManager.Instance.GetStateManager();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
		}
		public void OnDestroy()
		{
			smStateManager.DestroyTrackableBehavioursForTrackable(gameObject.GetComponent<Vuforia.TrackableBehaviour>().Trackable);
			Main.EnableLoader("Loader_AEP");
		}
		public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
		{
			if ((((newStatus == Vuforia.TrackableBehaviour.Status.DETECTED) || (newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)) || (newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)))
			{
				OnScan(true);
			}
			else
			{
				OnScan(false);
			}

		}
		public void OnScan(bool track)
		{
			switch (track)
			{
				case true:
					MenuController.ShowScanImage(false);
					MenuController.ShowTapActivateImage(true);
					Animate(true);
					break;
				case false:
					MenuController.ShowScanImage(true);
					MenuController.ShowTapActivateImage(false);
					Animate(false);
					break;
				default:
					OnScan(false);
					break;
			}
			
		}
		public void Animate(bool animate)
		{
			switch (animate)
			{
				case true:
					EnableLetterColliders(false);
					AEP_Utilities.AnimationUtils.PlayAnimation("AEP_Logo_02", "Start", false, "Default");
					AnimateLetters();
					break;
				case false:
					EnableLetterColliders(false);
					AEP_Utilities.AnimationUtils.RewindAnimation("AEP_Logo_02", "Start", "Default");
					AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02", true, "Shader Forge/Unlit_Op");
					AEP_Utilities.MaterialUtils.SetObjectColor("AEP_Logo_02", true, UnityEngine.Color.white);
					AEP_Utilities.MaterialUtils.SetObjectAlpha("AEP_Logo_02", true, 0f);
					ResetLetterUV();
					break;
				default:
					break;
			}
			
		}
		public void EnableLetterColliders(bool enable)
		{
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, true, enable);
		}
		public void ResetLetterUV()
		{
			UnityEngine.Renderer[] component = null;

			component = gameObject.GetComponentsInChildren<UnityEngine.Renderer>();
			foreach (var iterator_144 in component)
			{
				if (iterator_144.material.HasProperty("_Texture"))
				{
					iterator_144.material.SetTextureOffset("_Texture", UnityEngine.Vector2.zero);
				}

			}
		}
		public System.Collections.IEnumerator eAnimateLetters(float waitTime)
		{
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_A1/AEP_Cube_A1", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_E2/AEP_Cube_E2", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_A1/AEP_Cube_A1", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_E2/AEP_Cube_E2", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_U/AEP_Cube_U", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_L/AEP_Cube_L", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_U/AEP_Cube_U", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_L/AEP_Cube_L", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_G/AEP_Cube_G", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_G/AEP_Cube_G", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_M/AEP_Cube_M", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_P/AEP_Cube_P", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_M/AEP_Cube_M", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_P/AEP_Cube_P", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_E1/AEP_Cube_E1", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_A2/AEP_Cube_A2", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_E1/AEP_Cube_E1", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_A2/AEP_Cube_A2", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_N/AEP_Cube_N", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_S/AEP_Cube_S", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_N/AEP_Cube_N", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_S/AEP_Cube_S", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_T/AEP_Cube_T", true, true, 1f);
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("AEP_Logo_02/AEP_PT_O/AEP_Cube_O", true, true, 1f);
			yield return new UnityEngine.WaitForSeconds(waitTime);
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_T/AEP_Cube_T", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("AEP_Logo_02/AEP_PT_O/AEP_Cube_O", true, "Shader Forge/Unlit");
			EnableLetterColliders(true);
		}
		private void AnimateLetters()
		{
			this.StartCoroutine(eAnimateLetters(0.1f));
		}
	}


}
