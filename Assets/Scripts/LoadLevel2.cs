using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gate;
    public GameObject Position;
    public float Speed;
    private Camera MainCamera;
    private bool moveCamera;

    public Image Black;
    public float WaitTime;
    public bool fade = false;
    public bool loading = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player" && Gate.GetComponent<GateScript>().Open)
        {
            Invoke("EndOfLevel1", WaitTime);
        }
    }

    private void EndOfLevel1()
    {
        fade = true;
    }

    //public void EndOfLevel1()
    //{
    //    Player.GetComponent<RigidbodyCharacter>().speed = 0;
    //    Destroy(Player.transform.GetChild(0));
    //    MainCamera = Player.GetComponent<CharacterStats>().MainCamera;
    //    moveCamera = true;
    //}

    void Update()
    {
        if (fade)
        {
            Color newColour = Black.material.color;
            newColour.a += Speed;
            if(newColour.a > 255)
                newColour.a = 255;
            Black.material.color = newColour;
            if(newColour.a >= 255 && !loading)
            {
                loading = true;
                SceneManager.LoadScene("Level 2 - Volcano", LoadSceneMode.Single);
            }
        }


        //if (moveCamera)
        //    MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, Position.transform.position, Speed * Time.deltaTime);
    }
}
