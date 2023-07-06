using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 20f;

    public Text BoxDestoryedText;

    public int noOfBoxs = 3;

    MeshRenderer boxMaterial;
    public Slider slider;

    private GameObject ScoreManagerObject;

    void Start()
    {
        boxMaterial = GetComponent<MeshRenderer>();
        ScoreManagerObject = GameObject.Find("ScoreManagerObject");
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            ScoreManagerObject.GetComponent<ScoreManager>().addScore(1);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        float scalar = (float)(maxHealth - currentHealth);
        scalar = scalar / 10;
        boxMaterial.material.SetColor("_EmissionColor", Color.red * scalar);
        slider.value = CalculateHealth();
        Debug.Log("Slider value:" + slider.value);
    }

    float CalculateHealth()
    {
        return (float)(currentHealth / maxHealth);
    }
 
}
