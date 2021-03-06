using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxScript : MonoBehaviour
{
    public GameObject b1Fuse;
    public MeshRenderer b1Button;
    public Material[] buttonMaterials;

    public Collider fuseCol, buttonCol;
    public AudioSource fuseAudio, buttonAudio;

    public void PlaceFuse()
    {
        if(GameController.instance.hasFuse) //If you have the fuse
        {
            b1Fuse.SetActive(true); //Active fuse in box
            b1Button.material = buttonMaterials[1]; //Change button to red

            GameController.instance.fuseInPlace = true; //Say that fuse is in place
            GameController.instance.hasFuse = false; //Remove fuse from inventory

            fuseAudio.Play(); //Play fuse placemente audio
            fuseCol.enabled = false; //Disable fuse place collider
        }
    }

    public void ActivateB1Energy()
    {
        if(!GameController.instance.energyRestored) //If energy is not restored!
            buttonAudio.Play(); //Play activate button Audio

        if(GameController.instance.fuseInPlace) //If fuse is in place
        {
            GameController.instance.energyRestored = true; //Restores Energy in B1 (Lab)
            b1Button.material = buttonMaterials[2]; //Change button to green
            GameController.instance.ChangeObjective(4); //Complete objective

            buttonAudio.Play(); //Play activate button Audio
            buttonCol.enabled = false; //Disable button collider
        }
    }

    public void GetFuseItem()
    {
        GameController.instance.hasFuse = true; //Add fuse to inventory
        GameController.instance.ChangeObjective(3); //Complete objective
    }

}
