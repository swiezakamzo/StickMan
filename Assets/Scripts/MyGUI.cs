using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
	public GameObject player;
    public GameObject gameManager;
    public GameManager.typeOfGame typGry;

    bool hasPlayer = false;

	Text health;
	Text armor;
	Text ammo;

	// Use this for initialization
	void Start () 
	{
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        typGry = gameManager.GetComponent<GameManager>().typGry;

        if(typGry == GameManager.typeOfGame.multi)
            player = GameObject.FindGameObjectWithTag("PlayerMulti");
        else
            player = GameObject.FindGameObjectWithTag("Player");

        health = GameObject.Find ("GUI/Canvas/Health/Value").GetComponent<Text> ();
		armor = GameObject.Find ("GUI/Canvas/Armor/Value").GetComponent<Text> ();
		ammo = GameObject.Find ("GUI/Canvas/Ammo/Value").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (hasPlayer)
            TakePlayer();

        if (typGry == GameManager.typeOfGame.multi)
        {
            health.text = player.GetComponent<PlayerMulti>().GetHealth();
            armor.text = player.GetComponent<PlayerMulti>().GetArmor();
            ammo.text = player.GetComponent<PlayerMulti>().GetAmmo();
        }
        else
        {
            health.text = player.GetComponent<Player>().GetHealth();
            armor.text = player.GetComponent<Player>().GetArmor();
            ammo.text = player.GetComponent<Player>().GetAmmo();
        } 
	}

    void TakePlayer()
    {
        if(typGry == GameManager.typeOfGame.multi)
            player = GameObject.FindGameObjectWithTag("PlayerMulti");
        else
            player = GameObject.FindGameObjectWithTag("Player");
        hasPlayer = true;
    }

    void UpdateGui()
    {
        return;
    }
}
