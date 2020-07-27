using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void TapDrawMethod();
    public TapDrawMethod tapDrawMethod;

    [SerializeField]
    private Slider staticSlider;
    [SerializeField]
    private Slider innerSlider;
    [SerializeField]
    private Slider dynamicSlider;


    private float r_c; //定円の半径
    private float r_m; //動円の半径
    private float r_d; //描画円の半径

    public bool isDraw = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapDrawButton()
    { 
        tapDrawMethod();
        isDraw = true;
    }

    public void GetSliderPram()
    {

    } 
}
