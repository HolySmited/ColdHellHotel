/*  Script: ObjectFader.cs
    Author: Zackary Hoyt
    Date:   2016 January 19

    Description:
    Manages the Alpha Level of Nearby Objects
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectFader : MonoBehaviour
{
/*    void FixedUpdate()
    {
        objectFade();
        //objectClipCoverup();
    }

    void objectFade()
    {
        //  Get RayCast Variables
        Vector3 rayOrigin = transform.position, rayDir = transform.forward;
        float rayRadius = PCSettings.staticRef.dist_a1;

        List<GameObject> currentHits = new List<GameObject>();
        //  SphereCastAll
        RaycastHit[] spherecastHits = Physics.SphereCastAll(rayOrigin, rayRadius, rayDir, rayRadius, PCSettings.staticRef.fadingObjectsLM);
        foreach (RaycastHit hitInfo in spherecastHits)
        {
            Renderer r = hitInfo.transform.GetComponent<Renderer>();
            Vector3 colliderPoint = hitInfo.collider.ClosestPointOnBounds(rayOrigin);
            Color color = r.material.color;
            //  Ensure Hit Object is Within a Region Around and Before the Playe (Cone with Spherical Base).
            float rotation = Vector3.Angle(rayDir, rayOrigin - colliderPoint);
            float dist = Vector3.Distance(transform.position, hitInfo.collider.ClosestPointOnBounds(transform.position));
            float alphaBasePercent = dist / PCSettings.staticRef.dist_a1;
            //  Account for larger objects having distant-centers
            if (((rotation < 90 || rotation > 270) && alphaBasePercent >= 0.5f) || alphaBasePercent >= 1)
            {
                color.a = 1;
                r.material.color = color;
                continue;
            }
            r.material.SetFloat("_Mode", 2);
            //  Adjust the Alpha Level Relative to the Distance from the Player to the Specified Object
            color.a = Mathf.Clamp(Mathf.Pow(alphaBasePercent, 4), 0, 1);
            r.material.color = color;
            r.material.SetColor("_Color", color);
            r.material.shader = Shader.Find("Standard");
        }
    }

    List<Rect> rects = new List<Rect>();
    public void objectClipCoverup()
    {
        rects.Clear();
        //  Get RayCast Variables
        Vector3 rayOrigin = transform.position, rayDir = transform.forward;
        float rayRadius = PCSettings.staticRef.dist_a1;

        List<GameObject> currentHits = new List<GameObject>();
        //  SphereCastAll
        RaycastHit[] spherecastHits = Physics.SphereCastAll(rayOrigin, rayRadius, rayDir, rayRadius, PCSettings.staticRef.fadingObjectsLM);
        foreach (RaycastHit hitInfo in spherecastHits)
        {
            //  Ensure Hit Object is Within a Region Around and Before the Playe (Cone with Spherical Base).
            Vector3 colliderPoint = hitInfo.collider.ClosestPointOnBounds(rayOrigin);
            float rotation = Vector3.Angle(rayDir, rayOrigin - colliderPoint);
            float dist = Vector3.Distance(transform.position, colliderPoint);
            float rectScale = dist / PCSettings.staticRef.dist_a1;
            //  Account for larger objects having distant-centers
            if (((rotation < 90 || rotation > 270) && rectScale >= 0.5f) || rectScale >= 1)
                continue;

            Vector2 screenPt = Camera.main.WorldToScreenPoint(colliderPoint);
            Vector2 size = new Vector2(Screen.width * (1 - rectScale), Screen.height * (1 - rectScale));
            Rect rect = new Rect(screenPt.x - size.x / 2, screenPt.y - size.y / 2, size.x, size.y);
            //Vector3 front = transform.position + transform.forward;
            //Vector2 frontToScreen = Camera.main.WorldToScreenPoint(front);
            //Rect rect = new Rect(frontToScreen.x - size.x / 2, frontToScreen.y - size.y / 2, size.x, size.y);
            rects.Add(rect);
        }
    }*/

    /*
    void OnGUI()
    {
        foreach (Rect rect in rects)
            GUIDrawRect(rect, Color.black);
    }
    private static Texture2D _staticRectTexture = new Texture2D(1, 1);
    private static GUIStyle _staticRectStyle = new GUIStyle();
    public static void GUIDrawRect(Rect rect, Color color)
    {
        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;

        GUI.Box(rect, GUIContent.none, _staticRectStyle);
    }
    */
}