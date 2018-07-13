using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPanelController : MonoBehaviour {

    public GameController gameController;
    public Creature creature;
    public ScalarController scalarController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        scalarController.currentValue = creature.maxHealth;
    }

    public void ClosePanel()
    {
        creature.healthBar.GetComponent<HealthBarController>().SetHealth(scalarController.currentValue); 
        gameController.CloseMaxHealthPanel();
    }
}
