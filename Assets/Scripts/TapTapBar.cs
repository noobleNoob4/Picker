using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapTapBar : MonoBehaviour
{
    [SerializeField] public PlayerMovement Speed;
    [SerializeField] private Image tapTapImage;
    private float maxTaptap;

    private void Start()
    {

        maxTaptap = Speed.speed;
        tapTapImage.fillAmount = 10f;


    }
    private void Update()
    {
        maxTaptap = 100f;
        tapTapImage.fillAmount = Speed.speed / maxTaptap;
        

    }

}
