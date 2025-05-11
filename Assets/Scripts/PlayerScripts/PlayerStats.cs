using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Hp;
    public int MaxHp=100;
    public float MoveSpeed=10f;
    public int Coins=0;
    public int Score=0;
    public int Keys = 0;


    public Slider slider;
    public TMP_Text text_Hp;
    public TMP_Text text_Score;
    public TMP_Text text_Coins;
    public TMP_Text text_Bullets;
    public TMP_Text text_Keys;

    public IWeapon gun;



    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<MontirovkaScript>();
        Hp = MaxHp;

        slider.value = Hp;
        text_Hp.text = Hp.ToString();
        text_Coins.text = Coins.ToString();
        text_Score.text = "Score: " + Score;
        text_Bullets.text = $"{gun.CurrentBullets}/{gun.MaxBullets}";
        text_Keys.text = Keys.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Hp;
        text_Hp.text = Hp.ToString();
        text_Coins.text = Coins.ToString();
        text_Score.text = "Score: " + Score;
        text_Bullets.text = $"{gun.CurrentBullets}/{gun.MaxBullets}";
        text_Keys.text = Keys.ToString();


    }


}
