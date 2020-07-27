using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    int count; // 頂点の数
    private int timeScale = 2; //描画の粗さ
    private float time;

    [SerializeField]
    private float r_c; //定円の半径
    [SerializeField]
    private float r_m; //動円の半径
    [SerializeField]
    private float r_d; //描画円の半径
    [SerializeField]
    private UIManager uIManager;

    



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();


        //デリゲータの登録
        uIManager.tapDrawMethod = DrawGlaph;

        r_c = r_c * 2.7f / 6f;
        r_d = r_d * 2.7f / 6f;

        r_m = r_m * 2.7f / 6f;

    }

    // Update is called once per frame
    void Update()
    {
        if (uIManager.isDraw)
        {
            DrawGlaph();
        }

    }

    float CalParameterX(float r_c,float r_m,float r_d)
    {
        float time = Time.time*timeScale;
        //time += 0.0001f;
        float x = (r_c - r_m) * Mathf.Cos(time) - r_d * Mathf.Cos(((r_c + r_m) / r_m) * time);
        return x;
    }

    float CalParameterY(float r_c, float r_m, float r_d)
    {
        float time = Time.time * timeScale;


        float x = (r_c - r_m) * Mathf.Sin(time) - r_d * Mathf.Sin(((r_c + r_m) / r_m) * time);
        return x;
    }

    float InCalParameterX(float r_c, float r_m, float r_d)
    {
        float time = Time.time * timeScale;

        float x = (r_c - r_m) * Mathf.Cos(time) + r_d * Mathf.Cos(((r_c - r_m) / r_m) * time);
        return x;
    }

    float InCalParameterY(float r_c, float r_m, float r_d)
    {
        float time = Time.time * timeScale;

        float x = (r_c - r_m) * Mathf.Sin(time) - r_d * Mathf.Sin(((r_c - r_m) / r_m) * time);
        return x;
    }

    private void DrawGlaph()
    {

            count++;
            lineRenderer.positionCount = count;
            lineRenderer.SetPosition(count - 1, new Vector3(CalParameterX(r_c, r_m, r_d), CalParameterY(r_c, r_m, r_d) + 2.0f, 0f)); //位置情報
        if (count >= 300)
        {
            uIManager.isDraw = false;
        }
    }
}
