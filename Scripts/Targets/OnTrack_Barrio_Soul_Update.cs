using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using AEP_Utilities;

namespace Vuforia
{
    public class OnTrack_Barrio_Soul_Update : AEPImageTrackerBase
    {
        public GameObject infoPanel;
        public List<AudioClip> musicList;
        public List<Sprite> thumbList;
        public string[] titleList;
        public List<string> descList;
        public UnityEngine.UI.Image portrait;
        public TextMeshProUGUI title;
        public TextMeshProUGUI text;
        public TextMeshProUGUI playButtonText;
        public Scrollbar scrollBar;

        private string bioName;
        private GameObject wall;
        private GameObject rootObject;

        void Awake()
        {
            infoPanel = GameObject.Find("Canvas_BS/Pnl_Info");
            MenuController.SetPanelScale("Canvas_BS/Pnl_Info", Vector3.zero);

            if (testing) { init(); }
        }

        void Start()
        {
            UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", false);
            UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", false);

            mTrackableBehaviour = GetComponent<TrackableBehaviour>();

            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);

                if(!testing)
                {
                    AssetBundleUtils.GetAssetBundle(this, playerPrefsValue, assetBundle, asset, init);
                }

                MenuController.HideInfoGraphics();
            }
        }

        void OnDestroy()
        {
            TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
            Main.EnableLoader(loaderName);
        }

        public override void onScan(bool tracked)
        {
            switch (allowTracking)
            {
                case true:
                    switch (tracked)
                    {
                        case true:
                            ObjectUtils.ShowObject(rootObject, true, true);
							animate(true);
							MenuController.ShowScanImage(false);
                            break;

                        case false:
                            ObjectUtils.ShowObject(rootObject, true, false);
							animate(false);
							UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", false);
							UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", false);
							UnityGUIUtils.EnablePanel(infoPanel, false);
							UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);
                            AudioVideoUtils.SetMovieTextureState(gameObject, "Pause");
                            AudioVideoUtils.SetMovieTextureState(gameObject, "Rewind");
                            MenuController.ShowScanImage(true);
							break;
                    }
                    break;

                case false:
                Debug.Log("Asset not ready yet!");
                    break;
            }
        }

        public override void animate(bool animate)
        {
            switch (animate)
            {
                case true:
                    PlayWall();
                    break;

                case false:
                    AnimationUtils.RewindAnimation("CK_BSM_Record", "Reveal", "Default");
					AudioVideoUtils.SetMovieTextureState(gameObject, "Pause");
					AudioVideoUtils.SetMovieTextureState(gameObject, "Rewind");
					ClosePanel();
					AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
					ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, false);
					ObjectUtils.EnableCollider("_Colliders", true, false);
					Delay.CancelAllLeanTween();
					Delay.CancelAllDelays(this);
                    break;
            }
        }

        public void init()
        {
            VideoClip clip = new VideoClip();

            if (testing)
            {
                rootObject = GameObject.Find("Root_BarrioSoul");
            }
            else
            {
                rootObject = GameObject.Find(asset + "(Clone)");

                MaterialUtils.SetObjectShader(gameObject, true, "Unlit/Texture");

                MaterialUtils.SetObjectShader("CK_BSM_Crosno_Mesh", false, "Unlit/Texture Double Sided");
                MaterialUtils.SetObjectShader("CK_BSM_Wall", false, "Unlit/Texture Double Sided");

                MaterialUtils.SetObjectShader("CK_BSM_Record_Mesh", false, "Unlit/Texture");

                MaterialUtils.SetObjectShader("CK_BSM_Mask", false, "Mask/DepthMask");

                MaterialUtils.SetObjectShader("CK_BSM_Par_Note1", false, "Mobile/Particles/Alpha Blended");
                MaterialUtils.SetObjectShader("CK_BSM_Par_Note3", false, "Mobile/Particles/Alpha Blended");
                MaterialUtils.SetObjectShader("CK_BSM_Par_Note4", false, "Mobile/Particles/Alpha Blended");
                MaterialUtils.SetObjectShader("CK_BSM_Par_Records1", false, "Mobile/Particles/Alpha Blended");

                TransformUtils.SetObjectParent(rootObject, gameObject);

                clip = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<VideoClip>("Ck_Bsm_Whole");
                                
                musicList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("CharlieAndTheJives-EsperaUnTantito"));
                musicList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("RhythmHeirs-StrangeWorld"));
                musicList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("SonnyPowel+TheNightDreamers-MrPitiful"));
                musicList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("TheElPasoDrifters-ForYourLove"));
                musicList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("Bobby+ThePremier-WhatAboutOneMoreTime"));

                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_BordComb"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_Rythmairs"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_LittleMike"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_EPDrifters"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_Crosno"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_Jives"));
                thumbList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<Sprite>("CK_BSM_THMB_NiteDreamers"));

                //AudioVideoUtils.SetMovieFilePath(gameObject, "Ck_Bsm_Whole");
                AudioVideoUtils.SetMoviePlayerMesh(gameObject.name, "CK_BSM_Wall");
            }
            ObjectUtils.ShowObject(gameObject, true, false);

            wall = GameObject.Find("CK_BSM_Wall");
            wall.GetComponent<VideoPlayer>().clip = clip;

            portrait = GameObject.Find("Img_Portrait").GetComponent<UnityEngine.UI.Image>();

			title = GameObject.Find("TMP_Title").GetComponent<TextMeshProUGUI>();

			text = GameObject.Find("TMP_Text").GetComponent<TextMeshProUGUI>();

			playButtonText = GameObject.Find("TMP_PlaySound").GetComponent<TextMeshProUGUI>();

            Button soundPlayButton = GameObject.Find("Btn_Play").GetComponent<Button>();
            soundPlayButton.onClick.AddListener(() => { GameObject.Find("CK_BSM_Record_Mesh").GetComponent<PlayAudioOnObject>().PlayAudio(); });


            descList.Add("The Birdland Combo is credited with being the first band in El Paso, Texas, to play rock and roll music.  The Combo was born from several iterations including The Jeffersonians, started by then-Jefferson High School band director, Roy Wilson.  Eventually, they evolved into The Birdland Combo.  The Combo's name nodded to Chicago's jazzy, well-known Birdland Club.\n\nThe Birdland Combo was the first to publicly perform rock and roll music, and performed an impromptu version of Fats Domino's \"Please Don't Leave Me\" hit with visiting musician Paul Johnson.  That same performance marked an important milestone, worthy of our attention: it was also the first public performance wherein Mexican and Mexican American youth played onstage with an African American singer.\n\nThe Birdland Combo opened doors for new sounds, new cross-cultural collaborations, and tore down previously held standards regarding race during the tumultuous 1950s and 1960s in the United States without even trying: music was the unintended vehicle that created the beginning of social change in the El Paso, Texas area.");
			descList.Add("The Rhythmairs band was born from several musicians who were students at Bowie High School in south El Paso, Texas. They were encouraged by a Jesuit priest on assignment at Segundo Barrio's Sacred Heart Church, Father Harold J. Rahm, to create music outside of school.  Father Rahm obtained performance spaces for the students, and created events for area youth to showcase local talent.  Father Rahm is even rumored to have obtained a loan for the musicians to buy new instruments at one point, which was all reportedly paid back, down to the cent.\n\nOut of their combined efforts emerged the Rhythmairs, who began to experiment beyond just \"big band\" sound of the time, and incorporated Mexican music into their performance repertoire. By 1956, the Rhythmairs had grown to include 12 members, which included youth from different racial and cultural backgrounds.  Their musical sound carried the same diversity and celebrated the ways traditional Mexican music, rock and roll, and soul could be morphed into a sound that was distinctively from Segundo Barrio.  The Rhythmairs are remembered over the years for having shared the stage with The Platters, Sunny Ozuna, Ray Camacho, and Fats Domino.  Although The Rhythmairs eventually disbanded in 1956, they reunited for several big events during the 1970s.");
			descList.Add("Mike Saenz started his musical career when he was 17 years old and learned to play piano.  Thereafter, he garnered a name for himself, \"Little Mike,\" which stuck with him ever since the 1950s.  Little Mike was born in Ciudad Juarez, Chihuahua, Mexico, but moved to Segundo Barrio in El Paso, Texas, and later attended Bowie High School.  Little Mike moved to East Los Angeles, California in the 1960s and continued to play music there, bringing a spark of the El Paso sound to the west coast.  In 1977, he returned to El Paso, and started a new band, Little Mike and the Night Drifters.  Little Mike has played with a great deal of musicians and formal groups over the years, the most well-known iteration being \"Little Mike and the Blue Kings.\"  Little Mike has continued to play the music his community loves through the years, which has a special love for oldies and cumbias.");
			descList.Add("The El Paso Drifters was a band that came out of the Segundo Barrio area of El Paso, Texas, who recorded with Steve Crosno on The Frogdeath Records.  The band was featured as performers at Steve Crosno Day on July 9th, 1967 which consisted of a 4,000 person crowd at the El Paso County Coliseum.  The El Paso Drifters were known to share the stage with Sunny and the Sunliners and Ray Camacho, among others.\n\nMarta \"Marty\" Sifuentes, a Bowie High School grad, joined the group in 1958.  Sifuentes was said to be one of the best rock and roll singers in the area, and has a special place in the music world:  during her musical career, she was one of the only front and center female vocalists.  The El Paso Drifters performed together for over 20 years.");
			descList.Add("Steve Crosno started his radio career at Las Cruces High School in nearby Las Cruces, New Mexico.  Crosno had a colorful career in the music world, both locally and nationally.  Crosno was known for his silly on-air antics as a radio disc jockey, his unmatched love of Pepsi and fried chicken, and above all else, his genuine dedication to music at all costs.  Perhaps Crosno's most notable contribution was providing air play for Mexican, Mexican American, and African American musicians in an era marred by an absolute lack of representation of minority groups on the air, or any available media at the time.\n\nCrosno is also credited with having, perhaps unwittingly, created an El Paso tradition:  his radio show, Cruising With Crosno, aired on Sunday afternoons and consisted of what is now referred to as \"Chuco Soul\" sound.  Local radio personalities in El Paso and Ciudad Juarez have beautifully continued the tradition Crosno started, much to the joy of residents across the area.\n\nAs a champion for youth, Crosno developed numerous events for local teens.  One example is Crosno's television show, \"The Crosno Hop\", that aired from the 1960's until the 1980's.  Kids were charged twenty-five to fifty cents to get into the studio to boogie down to Crosno's mixings, similar to American Bandstand, or Soul Train.\n\nCrosno recorded albums with several bands out of his in-home studio on his label, The Frogdeath, to include the Nite Dreamers, Bobby Rosales and the Premiers, and the El Paso Drifters.");
			descList.Add("Charlie Miller and the Jives started out of Segundo Barrio, in the 1960s.  Charlie Miller was a mere 11 years old when he and his brothers Donnie and Albert started playing together.  Soon thereafter, the band grew to include several neighborhood friends and additional family members.\n\nThe Jives' bicultural sound ran the gamut to include traditional Mexican corridos all the way to rock and roll ballads.  They are best known for singles \"Espera Un Tantito\" and \"Mi Gordita.\"  They were often compared to Sunny Ozuna and Little Joe and the Latinaires because of their complex sound, which so clearly sliced through the previously standing genre ideas about music.\n\nThe Jives went on to record albums for Teardrop Records, which historically recorded big name Tejano bands.");
			descList.Add("As the 50's drew to a close, the Nite Dreamers rose to prominence with their interpretation of Rhythm & Blues, with a latin twist. Known for their soulful horn sound, The Nite Dreamers notoriously dominated the battle of the bands scene in El Paso, receiving first place for eight years straight. As a result, they were often found opening for major headliners, such as James Brown, The Bobby Blues Band, The Drifters, The Coasters, and The Shirelles. The Nite Dreamers were even invited to perform on a USO tour to military bases.");

			UnityGUIUtils.EnablePanel(infoPanel, false);
			UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);

			allowTracking = true;

			onScan(false);
        }

        public void PlayWall()
        {
            AudioVideoUtils.SetMovieTextureState(gameObject, "Play");
            //wall.GetComponent<VideoPlayer>().Play();
			AnimationUtils.PlayParticles("CK_BSM_Par_Note1", true);
			AnimationUtils.PlayParticles("CK_BSM_Par_Note3", true);
			AnimationUtils.PlayParticles("CK_BSM_Par_Note4", true);
			AnimationUtils.PlayParticles("CK_BSM_Par_Records1", true);
			Delay.DelayFunction(this, RevealRecord, 3f);
        }

        public void RevealRecord()
        {
            AnimationUtils.PlayAnimation("CK_BSM_Record", "Reveal", false, "Default");
			Delay.DelayFunction(this, RotateRecord, 2.09f);
        }

        public void RotateRecord()
        {
            TransformUtils.RotateAroundAxis("CK_BSM_Record_Mesh", Vector3.forward, 360f, 4f, -1, true);
			ObjectUtils.EnableCollider("_Colliders", true, true);
			ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, true);
			AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[4]);
			AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
			SetBioName("");
        }

        public void RevealPanel()
        {
            TransformUtils.ScaleTween(infoPanel, new UnityEngine.Vector3(1f, 1f, 1f), 0.75f, LeanTweenType.easeOutBounce);
			UnityGUIUtils.EnablePanel(infoPanel, true);
			UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, true);
        }

        public void SetBarrioGUI(int index)
        {
            portrait.sprite = thumbList[index];
			title.text = titleList[index];
			text.text = descList[index];
			AudioVideoUtils.PlayAudioSource("CK_BSM_Record_Mesh", false);
			ObjectUtils.EnableCollider("_Colliders", true, false);
			MenuController.EnableSVGImageButton("Btn_PlayVideo", false);
			MenuController.EnableSVGImageButton("Btn_Play", false);
			MenuController.ShowButton("Btn_Play", false);
			scrollBar.value = 1f;
			switch (bioName)
			{
				case "CK_BSM_P1":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[1]);
					break;
				case "CK_BSM_P2":
					MenuController.ShowButton("Btn_Play", false);
					playButtonText.text = "";
					break;
				case "CK_BSM_P3":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[2]);
					break;
				case "CK_BSM_BSB_P4":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[3]);
					break;
				case "CK_BSM_P5":
					MenuController.EnableSVGImageButton("Btn_Play", true);
					playButtonText.text = "Play Sound";
					AudioVideoUtils.SetAudioSourceClip("CK_BSM_Record_Mesh", musicList[0]);
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
			
			ObjectUtils.EnableCollider("CK_BSM_Record_Mesh", false, false);
			RevealPanel();
        }

        public void ClosePanel()
        {
            MenuController.SetPanelScale("Canvas_BS/Pnl_Info", Vector3.zero);
			UnityGUIUtils.EnablePanel(infoPanel, false);
			UnityGUIUtils.EnablePanelBlockRaytrace(infoPanel, false);
			ObjectUtils.EnableCollider("_Colliders", true, true);
        }

        public void SetBioName(string name)
        {
            bioName = name;
        }

        public void PlayCrosnoVideo()
        {
            ClosePanel();
            UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", true);
			UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", true);
			AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Play");
        }

        public void CloseGUIVideoPanel()
        {
            AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Stop");
			AudioVideoUtils.SetMovieTextureState("Pnl_Video", "Rewind");
			UnityGUIUtils.EnablePanel("Canvas_BS/Pnl_Video", false);
			UnityGUIUtils.EnablePanelBlockRaytrace("Canvas_BS/Pnl_Video", false);
        }
    }
}