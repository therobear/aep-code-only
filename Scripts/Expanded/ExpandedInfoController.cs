using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ExpandedInfoController : MonoBehaviour
{
    public List<string> expandedInfoTitle = new List<string>();
    public List<string> expandedInfoText = new List<string>();
    public TextMeshProUGUI infoTitleObject;
    public TextMeshProUGUI infoTextObject;

    private Button buttonExpInfo;
    private GameObject canvasGroupInfoText;
    private GameObject scrollBar;

#region Global Functions ------------------------------------------------------------------------------------
    public void Start()
    {
        initText();

        buttonExpInfo = GameObject.Find("Btn_EXP_Info").GetComponent<Button>();

        canvasGroupInfoText = GameObject.Find("Pnl_EXP_Text");

        expInfoPanelCtrl("Hide");

        Scene currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case "AEP_BarrioSoul":
                infoTitleObject.text = expandedInfoTitle[0];

                infoTextObject.text = expandedInfoText[0];
                break;

            case "AEP_EXP_SisterCities":
                infoTitleObject.text = expandedInfoTitle[1];

                infoTextObject.text = expandedInfoText[1];
                break;

            case "AEP_EXP_Omecoatl":
                infoTitleObject.text = expandedInfoTitle[2];

                infoTextObject.text = expandedInfoText[2];
                break;

            case "AEP_EXP_ElPasoPortal":
                infoTitleObject.text = expandedInfoTitle[3];

                infoTextObject.text = expandedInfoText[3];
                break;

            case "AEP_EXP_AguaEsVida":
                infoTitleObject.text = expandedInfoTitle[4];

                infoTextObject.text = expandedInfoText[4];
                break;
        }
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
    public void initText()
    {
        expandedInfoTitle.Add("Barrio Soul");
        expandedInfoTitle.Add("Sister Cities");
        expandedInfoTitle.Add("Omecoatl");
        expandedInfoTitle.Add("PasoPortAll");
        expandedInfoTitle.Add("Agua Es Vida");

        expandedInfoText.Add("Dedicated to the  the rich Rhythm & Blues and Rock & Roll heritage of El Paso's Segundo Barrio, this mural showcases bands such as The El Paso Drifters, The Nite-Dreamers, Charlie Miller and the Jives, The Birdland Combo, The Rythmairs, and Little Mike. Also depicted is local legend, Steve Crosno, whose passion for music and community allowed many of these artists to rise to the forefront, and become known for their exceptional musical talent.\n\nVisit Cimi on the web at:\nArtist's website:\nhttp://www.cimione.com");
        expandedInfoText.Add("\"We see our work as an intersection between Mexican muralism and street art,\" says Ramon. \"It's about re-appropriating public spaces with images that are relatable to us as a community, and in which we are protagonists.\" LxsDos are based in El Paso, but they make art on both sides of the border. Their work often speaks to the close relationship between the cities. In their 2015 mural Sister Cities/Ciudades Hermanas Ramon and Christian painted Juarez and El Paso as two nearly identical women: \"The women are used as a metaphor for the connection between the border communities. The characters illustrated inside the sister's chain fence pattern shirt represent the people who have been at the mercy and directly affected by capitalist trade agreements and interests, which have a very notable impact on our communities. At the bottom, both landscapes converge at the center with a dried up river in between. It talks about our commonalities, like being illuminated by the same sun, but also about our struggles.\" - LxsDos. \n\nVisit Los Dos on the web at:\nFacebook:\nhttps://www.facebook.com/LxsDxs");
        expandedInfoText.Add("\"Meso-American serpents represent natural movement and our pre-Hispanic culture. One serpent symbolizes the feminine energy and the other serpent is the masculine energy. Everything in creation consist the balanced of two opposites: male/female; hot/cold; good/bad; night/day; positive/negative; left/right. It is this balanced human beings strive to maintain.\" - Gabriel Gaytan\n\nVisit Gabriel Gaytan on the web at:\nArtist's website:\nhttp://gaytanartworks.com");
        expandedInfoText.Add("The PasoPortAll mural drapes the border of El Paso, Texas and Ciudad Juarez, Mexico at the International Stanton St. Port of Entry, where an average of 1.2 million people cross per year.\n\n\"El Paso Port-All is inspired by the awe-inspiring sunsets, border culture, history, and traditions.\" - WERC\n\nVisit WERC on the web at\nArtist's website:\nhttp://www.wercworldwide.com/\nFacebook:\nhttps://facebook.com/wercworldwide");
        expandedInfoText.Add("\"Between Albuquerque and El Paso is a single body of water that has United us for centuries . It is the Rio Grande River also known as the Rio Bravo, Too Ba' aadii, and Kotsoi. This river has sustained generations of indigenous people from Colorado to the Gulf of Mexico acting as an important life force for irrigation and trade route to the north . Today because of Dams and over consumption and shifty negotiations of water rights, only twenty percent of the once thriving river makes it to the Gulf of Mexico and the people along the way… This mural honors the historical and traditional connection we have to water. The water that lives in us, is the water of centuries . It is an imperative realization we must have to protect our water, it is sacred, and it is what connects us all . This mural honors our Relationship with water with the understanding that it is water that gives us life.\" - Nani Chacon\n\nVisit Nani Chacon on the web at:\nFacebook:\nhttps://www.facebook.com/nani.chacon1\nInstagram:\nhttps://www.instagram.com/nanibah");
    }

//------------------------------------------------------------------------------------
    public void expInfoPanelCtrl(string state)
    {
        switch(state)
        {
            case "Hide":
                MenuController.EnableButton(buttonExpInfo, true);
                MenuController.ShowButton(buttonExpInfo, true);
                MenuController.EnablePanelBlockRaytrace(canvasGroupInfoText.name, false);
                MenuController.EnablePanel(canvasGroupInfoText, false);
                MenuController.EnablePanel("AEP_Menu_Canvas", true);
                MenuController.EnablePanelBlockRaytrace("AEP_Menu_Canvas", true);
                break;

            case "Show":
                MenuController.EnableButton(buttonExpInfo, false);
                MenuController.ShowButton(buttonExpInfo, false);
                MenuController.EnablePanelBlockRaytrace(canvasGroupInfoText.name, true);
                MenuController.EnablePanel(canvasGroupInfoText, true);
                MenuController.EnablePanel("AEP_Menu_Canvas", false);
                MenuController.EnablePanelBlockRaytrace("AEP_Menu_Canvas", false);
                break;
        }
    }
#endregion
}