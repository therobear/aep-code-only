//MD5Hash:59f8312cee642069f21c5a58283e7f01;
using Vuforia;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;


namespace Vuforia
{
	public class OnTrack_BarrioSoul : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public UnityEngine.GameObject infoPanel = null;
		public UnityEngine.AudioClip[] musicList = null;
		public UnityEngine.Sprite[] thumbList = null;
		public string[] titleList = null;
		public string[] descList = null;
		public UnityEngine.UI.Image portrait = null;
		public TMPro.TextMeshProUGUI title = null;
		public TMPro.TextMeshProUGUI text = null;
		public TMPro.TextMeshProUGUI playButtonText = null;
		private bool allowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private string bioName = "";
		public UnityEngine.UI.Scrollbar scrollBar = null;


		void Awake()
		{
			infoPanel = UnityEngine.GameObject.Find("Canvas_BS/Pnl_Info");
			MenuController.SetPanelScale("Canvas_BS/Pnl_Info", UnityEngine.Vector3.zero);
			if (testing)
			{
				init();
			}

		}
		void Start()
		{
			mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
				if (testing)
				{
				}
				else
				{
					AEP_Utilities.AssetBundleUtils.GetAssetBundle(this, playerPrefsValue, assetBundle, asset, init);
				}

				MenuController.HideInfoGraphics();
			}

		}
		public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
		{
			if ((((newStatus == Vuforia.TrackableBehaviour.Status.DETECTED) || (newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)) || (newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)))
			{
				onScan(true);
			}
			else
			{
				onScan(false);
			}

		}
		public void OnDestroy()
		{
			Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
			Main.EnableLoader(loaderName);
		}
		public void onScan(bool tracked)
		{
			switch (allowTracking)
			{
				case true:
					switch (tracked)
					{
						case true:
							AEP_Utilities.ObjectUtils.ShowObject("Root_BarrioSoul", true, true);
							animate(true);
							MenuController.ShowScanImage(false);
							break;
						case false:
							AEP_Utilities.ObjectUtils.ShowObject("Root_BarrioSoul", true, false);
							animate(false);
							AEP_Utilities.UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", false);
							AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", false);
							AEP_Utilities.UnityGUIUtils.EnablePanel(infoPanel, false);
							AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);
							MenuController.ShowScanImage(true);
							break;
						default:
							break;
					}
					
					break;
				case false:
					UnityEngine.Debug.Log(new System.Text.StringBuilder("Asset not ready yet!"));
					break;
				default:
					onScan(false);
					break;
			}
			
		}
		public void animate(bool animate)
		{
			switch (animate)
			{
				case true:
					playWall();
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation("CK_BSM_Record", "Reveal", "Default");
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Pause");
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Rewind");
					closePanel();
					AEP_Utilities.AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
					AEP_Utilities.ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, false);
					AEP_Utilities.ObjectUtils.EnableCollider("_Colliders", true, false);
					AEP_Utilities.Delay.CancelAllLeanTween();
					AEP_Utilities.Delay.CancelAllDelays(this);
					break;
				default:
					break;
			}
			
		}
		public void init()
		{
			AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
			portrait = UnityEngine.GameObject.Find("Img_Portrait").GetComponent<UnityEngine.UI.Image>();
			title = UnityEngine.GameObject.Find("TMP_Title").GetComponent<TMPro.TextMeshProUGUI>();
			text = UnityEngine.GameObject.Find("TMP_Text").GetComponent<TMPro.TextMeshProUGUI>();
			playButtonText = UnityEngine.GameObject.Find("TMP_PlaySound").GetComponent<TMPro.TextMeshProUGUI>();
			descList[0] = "The Birdland Combo is credited with being the first band in El Paso, Texas, to play rock and roll music.  The Combo was born from several iterations including The Jeffersonians, started by then-Jefferson High School band director, Roy Wilson.  Eventually, they evolved into The Birdland Combo.  The Combo's name nodded to Chicago's jazzy, well-known Birdland Club.\n\nThe Birdland Combo was the first to publicly perform rock and roll music, and performed an impromptu version of Fats Domino's \"Please Don't Leave Me\" hit with visiting musician Paul Johnson.  That same performance marked an important milestone, worthy of our attention: it was also the first public performance wherein Mexican and Mexican American youth played onstage with an African American singer.\n\nThe Birdland Combo opened doors for new sounds, new cross-cultural collaborations, and tore down previously held standards regarding race during the tumultuous 1950s and 1960s in the United States without even trying: music was the unintended vehicle that created the beginning of social change in the El Paso, Texas area.";
			descList[1] = "The Rhythmairs band was born from several musicians who were students at Bowie High School in south El Paso, Texas. They were encouraged by a Jesuit priest on assignment at Segundo Barrio's Sacred Heart Church, Father Harold J. Rahm, to create music outside of school.  Father Rahm obtained performance spaces for the students, and created events for area youth to showcase local talent.  Father Rahm is even rumored to have obtained a loan for the musicians to buy new instruments at one point, which was all reportedly paid back, down to the cent.\n\nOut of their combined efforts emerged the Rhythmairs, who began to experiment beyond just \"big band\" sound of the time, and incorporated Mexican music into their performance repertoire. By 1956, the Rhythmairs had grown to include 12 members, which included youth from different racial and cultural backgrounds.  Their musical sound carried the same diversity and celebrated the ways traditional Mexican music, rock and roll, and soul could be morphed into a sound that was distinctively from Segundo Barrio.  The Rhythmairs are remembered over the years for having shared the stage with The Platters, Sunny Ozuna, Ray Camacho, and Fats Domino.  Although The Rhythmairs eventually disbanded in 1956, they reunited for several big events during the 1970s.";
			descList[2] = "Mike Saenz started his musical career when he was 17 years old and learned to play piano.  Thereafter, he garnered a name for himself, \"Little Mike,\" which stuck with him ever since the 1950s.  Little Mike was born in Ciudad Juarez, Chihuahua, Mexico, but moved to Segundo Barrio in El Paso, Texas, and later attended Bowie High School.  Little Mike moved to East Los Angeles, California in the 1960s and continued to play music there, bringing a spark of the El Paso sound to the west coast.  In 1977, he returned to El Paso, and started a new band, Little Mike and the Night Drifters.  Little Mike has played with a great deal of musicians and formal groups over the years, the most well-known iteration being \"Little Mike and the Blue Kings.\"  Little Mike has continued to play the music his community loves through the years, which has a special love for oldies and cumbias.";
			descList[3] = "The El Paso Drifters was a band that came out of the Segundo Barrio area of El Paso, Texas, who recorded with Steve Crosno on The Frogdeath Records.  The band was featured as performers at Steve Crosno Day on July 9th, 1967 which consisted of a 4,000 person crowd at the El Paso County Coliseum.  The El Paso Drifters were known to share the stage with Sunny and the Sunliners and Ray Camacho, among others.\n\nMarta \"Marty\" Sifuentes, a Bowie High School grad, joined the group in 1958.  Sifuentes was said to be one of the best rock and roll singers in the area, and has a special place in the music world:  during her musical career, she was one of the only front and center female vocalists.  The El Paso Drifters performed together for over 20 years.";
			descList[4] = "Steve Crosno started his radio career at Las Cruces High School in nearby Las Cruces, New Mexico.  Crosno had a colorful career in the music world, both locally and nationally.  Crosno was known for his silly on-air antics as a radio disc jockey, his unmatched love of Pepsi and fried chicken, and above all else, his genuine dedication to music at all costs.  Perhaps Crosno's most notable contribution was providing air play for Mexican, Mexican American, and African American musicians in an era marred by an absolute lack of representation of minority groups on the air, or any available media at the time.\n\nCrosno is also credited with having, perhaps unwittingly, created an El Paso tradition:  his radio show, Cruising With Crosno, aired on Sunday afternoons and consisted of what is now referred to as \"Chuco Soul\" sound.  Local radio personalities in El Paso and Ciudad Juarez have beautifully continued the tradition Crosno started, much to the joy of residents across the area.\n\nAs a champion for youth, Crosno developed numerous events for local teens.  One example is Crosno's television show, \"The Crosno Hop\", that aired from the 1960's until the 1980's.  Kids were charged twenty-five to fifty cents to get into the studio to boogie down to Crosno's mixings, similar to American Bandstand, or Soul Train.\n\nCrosno recorded albums with several bands out of his in-home studio on his label, The Frogdeath, to include the Nite Dreamers, Bobby Rosales and the Premiers, and the El Paso Drifters.";
			descList[5] = "Charlie Miller and the Jives started out of Segundo Barrio, in the 1960s.  Charlie Miller was a mere 11 years old when he and his brothers Donnie and Albert started playing together.  Soon thereafter, the band grew to include several neighborhood friends and additional family members.\n\nThe Jives' bicultural sound ran the gamut to include traditional Mexican corridos all the way to rock and roll ballads.  They are best known for singles \"Espera Un Tantito\" and \"Mi Gordita.\"  They were often compared to Sunny Ozuna and Little Joe and the Latinaires because of their complex sound, which so clearly sliced through the previously standing genre ideas about music.\n\nThe Jives went on to record albums for Teardrop Records, which historically recorded big name Tejano bands.";
			descList[6] = "As the 50's drew to a close, the Nite Dreamers rose to prominence with their interpretation of Rhythm & Blues, with a latin twist. Known for their soulful horn sound, The Nite Dreamers notoriously dominated the battle of the bands scene in El Paso, receiving first place for eight years straight. As a result, they were often found opening for major headliners, such as James Brown, The Bobby Blues Band, The Drifters, The Coasters, and The Shirelles. The Nite Dreamers were even invited to perform on a USO tour to military bases.";
			AEP_Utilities.UnityGUIUtils.EnablePanel(infoPanel, false);
			AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);
			allowTracking = true;
			onScan(false);
		}
		public void playWall()
		{
			AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Play");
			AEP_Utilities.AnimationUtils.PlayParticles("CK_BSM_Par_Note1", true);
			AEP_Utilities.AnimationUtils.PlayParticles("CK_BSM_Par_Note3", true);
			AEP_Utilities.AnimationUtils.PlayParticles("CK_BSM_Par_Note4", true);
			AEP_Utilities.AnimationUtils.PlayParticles("CK_BSM_Par_Records1", true);
			AEP_Utilities.Delay.DelayFunction(this, revealRecord, 3f);
		}
		public void revealRecord()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("CK_BSM_Record", "Reveal", false, "Default");
			AEP_Utilities.Delay.DelayFunction(this, rotateRecord, 2.09f);
		}
		public void rotateRecord()
		{
			AEP_Utilities.TransformUtils.RotateAroundAxis("CK_BSM_Record_Mesh", UnityEngine.Vector3.forward, 360f, 4f, -1, true);
			AEP_Utilities.ObjectUtils.EnableCollider("_Colliders", true, true);
			AEP_Utilities.ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, true);
			AEP_Utilities.AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[4]);
			AEP_Utilities.AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
			setBioName("");
		}
		public void revealPanel()
		{
			AEP_Utilities.TransformUtils.ScaleTween(infoPanel, new UnityEngine.Vector3(1f, 1f, 1f), 0.75f, LeanTweenType.easeOutBounce);
			AEP_Utilities.UnityGUIUtils.EnablePanel(infoPanel, true);
			AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, true);
		}
		public void setBarrioGUI(int index)
		{
			portrait.sprite = thumbList[index];
			title.text = titleList[index];
			text.text = descList[index];
			AEP_Utilities.AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
			AEP_Utilities.ObjectUtils.EnableCollider("_Colliders", true, false);
			MenuController.EnableSVGImageButton("Btn_PlayVideo", false);
			MenuController.EnableSVGImageButton("Btn_Play", false);
			MenuController.ShowButton("Btn_Play", false);
			scrollBar.value = 1f;
			switch (bioName)
			{
				case "CK_BSM_P1":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AEP_Utilities.AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[1]);
					break;
				case "CK_BSM_P2":
					MenuController.ShowButton("Btn_Play", false);
					playButtonText.text = "";
					break;
				case "CK_BSM_P3":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AEP_Utilities.AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[2]);
					break;
				case "CK_BSM_BSB_P4":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AEP_Utilities.AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[3]);
					break;
				case "CK_BSM_P5":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AEP_Utilities.AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[0]);
					break;
				case "CK_BSM_P6":
					MenuController.ShowButton("Btn_Play", false);
					playButtonText.text = "";
					break;
				case "CK_BSM_Crosno_Mesh":
					MenuController.EnableSVGImageButton("Btn_PlayVideo", true);
					playButtonText.text = "Play Video";
					break;
				default:
					break;
			}
			
			AEP_Utilities.ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, false);
			revealPanel();
		}
		public void closePanel()
		{
			MenuController.SetPanelScale("Canvas_BS/Pnl_Info", UnityEngine.Vector3.zero);
			AEP_Utilities.UnityGUIUtils.EnablePanel(infoPanel, false);
			AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);
			AEP_Utilities.ObjectUtils.EnableCollider("_Colliders", true, true);
		}
		public void setBioName(string name)
		{
			bioName = name;
		}
		public void playCrosnoVideo()
		{
			closePanel();
			AEP_Utilities.UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", true);
			AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", true);
			AEP_Utilities.AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Play");
		}
		public void closeGUIVideoPanel()
		{
			AEP_Utilities.AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Stop");
			AEP_Utilities.AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Rewind");
			AEP_Utilities.UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", false);
			AEP_Utilities.UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", false);
		}
	}
}
