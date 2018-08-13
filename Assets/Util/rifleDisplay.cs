using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rifleDisplay : MonoBehaviour {

	public int maxBullets;
	public int currentBullets;

	//guns bullets
	public GameObject[] bullet_clip;
	public GameObject[] rifle_clip;
	public GameObject[] submachinegun_clip;

	public Image pistol_Image;
	public Image rifle_Image;
	public Image submachinegun_Image;

	public GameObject pistol;
	public GameObject rifle;
	public GameObject submachinegun;

	//"Reload" and "Reloading... #" text objects
	public GameObject Reload;
	public GameObject Reloading;
	public Text maxBullets_Obj;
	public Text currentBullets_Obj;

	//bool runOnce;
	//bool runUntilZero;

	public float reloadTimeRemaining;
	GameObject holdReloadingTime;
	Text holdReloadingTimeText;
	GameObject subText;

	Shoot m_API;
	int currentWeaponIndex;
	//int currentTotalBulletsShot;
	//bool lastReloadingBool;
	//need this because im a bad programmer
	bool usedForOneCase;
	// Use this for initialization
	void Start () {
		//usedForOneCase=false;
		//lastReloadingBool = false;
		//runOnce = true;
		//runUntilZero = false;
		Reload.GetComponent<Text>().enabled = false;
		Reloading.GetComponent<Text>().enabled = false;
		holdReloadingTime = GameObject.FindWithTag("Reloading");
		subText = GameObject.FindWithTag("subText");
		holdReloadingTime.GetComponent<Text>().enabled = false;
		subText.GetComponent<Text>().enabled = false;

		m_API = GameObject.FindWithTag("Player").GetComponent<Shoot>();
	}
	
	// Update is called once per frame
	void Update () {
		m_API = GameObject.FindWithTag("Player").GetComponent<Shoot>();

		currentBullets_Obj.text = m_API.currentClip[m_API.currentWeapon].ToString();
		maxBullets_Obj.text = m_API.maxClip[m_API.currentWeapon].ToString();

		//Debug.Log(m_API.currentClip[m_API.currentWeapon]);

		if(m_API.currentWeapon == 0){
				pistol.SetActive(true);
				rifle.SetActive(false);
				submachinegun.SetActive(false);
				pistol_Image.enabled = true;
				rifle_Image.enabled = false;
				submachinegun_Image.enabled = false;
		}
		if(m_API.currentWeapon == 1){
			pistol.SetActive(false);
			rifle.SetActive(true);
			submachinegun.SetActive(false);
			pistol_Image.enabled = false;
			rifle_Image.enabled = true;
			submachinegun_Image.enabled = false;
		}
		if(m_API.currentWeapon == 2){
			pistol.SetActive(false);
			rifle.SetActive(false);
			submachinegun.SetActive(true);
			pistol_Image.enabled = false;
			rifle_Image.enabled = false;
			submachinegun_Image.enabled = true;
		}
		Debug.Log(m_API.maxClip[m_API.currentWeapon]);
		
		if(m_API.currentWeapon == 0){
			for(int i=0; i<15;i++){
				if(i >= m_API.currentClip[m_API.currentWeapon])
				{
					bullet_clip[i].GetComponent<Image>().enabled = false;
					
				}
			}
		}
		if(m_API.currentWeapon == 1){
			for(int i=0; i<12;i++){
				if(i >= m_API.currentClip[m_API.currentWeapon])
				{
					rifle_clip[i].GetComponent<Image>().enabled = false;
					
				}
			}
		}
		if(m_API.currentWeapon == 2){
			for(int i=0; i<45;i++){
				if(i >= m_API.currentClip[m_API.currentWeapon])
				{
					submachinegun_clip[i].GetComponent<Image>().enabled = false;
					
				}
			}		
		}
		
		
		if(m_API.currentClip[m_API.currentWeapon] == m_API.maxClip[m_API.currentWeapon]){
			//Debug.Log(m_API.currentClip[m_API.currentWeapon] + " " + m_API.maxClip[m_API.currentWeapon]);
				for(int j=0; j<m_API.maxClip[m_API.currentWeapon];j++){
					if(m_API.currentWeapon == 0){
						Debug.Log("Displaying bullet");
						bullet_clip[j].GetComponent<Image>().enabled = true;
						}
						if(m_API.currentWeapon == 1){
							rifle_clip[j].GetComponent<Image>().enabled = true;
						}
						if(m_API.currentWeapon == 2){
							submachinegun_clip[j].GetComponent<Image>().enabled = true;
						}
				}
		}
		//if out of ammo
		if(m_API.currentClip[m_API.currentWeapon] == 0 && !m_API.isReloading){
			Reload.GetComponent<Text>().enabled = true;
			Reloading.GetComponent<Text>().enabled = false;
			subText.GetComponent<Text>().enabled = true;
			holdReloadingTime.GetComponent<Text>().enabled = false;
		}
		if(m_API.isReloading){
			Reload.GetComponent<Text>().enabled = false;
			Reloading.GetComponent<Text>().enabled = true;
			subText.GetComponent<Text>().enabled = false;
			holdReloadingTime.GetComponent<Text>().enabled = true;

			holdReloadingTime = GameObject.FindWithTag("Reloading");
			holdReloadingTimeText = holdReloadingTime.GetComponent<Text>();
			reloadTimeRemaining -= Time.deltaTime;
			holdReloadingTimeText.text = reloadTimeRemaining.ToString("F2");
		}
		//Debug.Log("yo " + m_API.reloadTime[m_API.currentWeapon]);
		//when no reloading and clip is > 0
		if((!m_API.isReloading) && m_API.currentClip[m_API.currentWeapon] > 0){
			//Debug.Log("Done reloading1231");
			holdReloadingTime = GameObject.FindWithTag("Reloading");
			holdReloadingTimeText = holdReloadingTime.GetComponent<Text>();
			reloadTimeRemaining = m_API.reloadTime[m_API.currentWeapon];
			holdReloadingTimeText.text = reloadTimeRemaining.ToString("F2");

			Reload.GetComponent<Text>().enabled = false;
			Reloading.GetComponent<Text>().enabled = false;
			subText.GetComponent<Text>().enabled = false;
			holdReloadingTime.GetComponent<Text>().enabled = false;
		}
		/*
		lastReloadingBool = m_API.isReloading;
		//Debug.Log(lastReloadingBool);
		//check if we just shot a bullet
		if(currentTotalBulletsShot != m_API.totalBulletsShot){
			if(m_API.currentWeapon == 0){
				bullet_clip[currentBullets-1].SetActive(false);
			}
			if(m_API.currentWeapon == 1){
				rifle_clip[currentBullets-1].SetActive(false);
			}
			if(m_API.currentWeapon == 2){
				submachinegun_clip[currentBullets-1].SetActive(false);
			}
			currentTotalBulletsShot++;

			maxBullets = m_API.maxClip[m_API.currentWeapon];
			currentBullets = m_API.currentClip[m_API.currentWeapon];
			currentWeaponIndex = m_API.currentWeapon;
			maxBullets_Obj.text = maxBullets.ToString();
			currentBullets_Obj.text = currentBullets.ToString();

		}

		if(lastReloadingBool){
			Reload.SetActive(false);
			Reloading.SetActive(true);
			runUntilZero = true;	
		}
		//if the weapon being selected changes
		//Debug.Log(currentWeaponIndex);
		if(currentWeaponIndex != m_API.currentWeapon){
			maxBullets = m_API.maxClip[m_API.currentWeapon];
			currentBullets = m_API.currentClip[m_API.currentWeapon];
			currentWeaponIndex = m_API.currentWeapon;
			maxBullets_Obj.text = maxBullets.ToString();
			reloadTimeRemaining = m_API.reloadTime[m_API.currentWeapon];

			currentBullets_Obj.text = currentBullets.ToString();
			if(m_API.currentWeapon == 0){
				pistol.SetActive(true);
				rifle.SetActive(false);
				submachinegun.SetActive(false);
			}
			if(m_API.currentWeapon == 1){
				pistol.SetActive(false);
				rifle.SetActive(true);
				submachinegun.SetActive(false);
			}
			if(m_API.currentWeapon == 2){
				pistol.SetActive(false);
				rifle.SetActive(false);
				submachinegun.SetActive(true);
			}
		}
		m_API = GameObject.FindWithTag("Player").GetComponent<Shoot>();
		//only call this when 
		if(currentBullets == 0 && runOnce){
			Reload.SetActive(true);
		}
		
		//check when reload button pressed
		//bool isReloading in Shoot.cs

		//while reloading keep time
		if(runUntilZero){
			//Debug.Log("rloadi");
			holdReloadingTime = GameObject.FindWithTag("Reloading");
			holdReloadingTimeText = holdReloadingTime.GetComponent<Text>();
			holdReloadingTimeText.text = reloadTimeRemaining.ToString("F2");
			reloadTimeRemaining -= Time.deltaTime;
		}



		//if done reloading
		if(reloadTimeRemaining <= 0.1f || (runUntilZero == true && lastReloadingBool == false )) {
			//ok, now re-enable all bullets
			Debug.Log(maxBullets);
				for(int i=m_API.currentClip[m_API.currentWeapon]; i<maxBullets;i++){
					if(m_API.currentWeapon == 0){
						bullet_clip[i].SetActive(true);
					}
					if(m_API.currentWeapon == 1){
						rifle_clip[i].SetActive(true);
					}
					if(m_API.currentWeapon == 2){
						submachinegun_clip[i].SetActive(true);
					}
				}
			//
			reloadTimeRemaining = m_API.reloadTime[m_API.currentWeapon];
			holdReloadingTime = GameObject.FindWithTag("Reloading");
			holdReloadingTimeText = holdReloadingTime.GetComponent<Text>();
			holdReloadingTimeText.text = reloadTimeRemaining.ToString();
			runUntilZero = false;
			currentBullets = maxBullets;
			Reloading.SetActive(false);
			Debug.Log(currentBullets);
			currentBullets_Obj.text = currentBullets.ToString();
		}

		if(currentBullets != 0){
			Reloading.SetActive(false);
			reloadTimeRemaining = m_API.reloadTime[m_API.currentWeapon];
		}

		runUntilZero = false;
		*/
	}
}
