using Scene1;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scene1
{
    public class Scene1Controller : MonoBehaviour
    {
        [SerializeField] TMP_InputField PosX;
        [SerializeField] TMP_InputField PosY;
        [SerializeField] TMP_InputField PosZ;
        [SerializeField] TMP_InputField RotX;
        [SerializeField] TMP_InputField RotY;
        [SerializeField] TMP_InputField RotZ;
        [SerializeField] TMP_InputField ScaleX;
        [SerializeField] TMP_InputField ScaleY;
        [SerializeField] TMP_InputField ScaleZ;
        [SerializeField] TMP_InputField Roll;
        [SerializeField] TMP_InputField Pitch;
        [SerializeField] TMP_InputField Yaw;
        [SerializeField] TMP_Text SwitcherText;
        [SerializeField] Button AdvButton;
        [SerializeField] Animator camAnimator;
        public Animation ringAnimation;

        float posX, posY, posZ;
        float pitch = 0, yaw = 0, roll = 0;
        float prevPitch, prevYaw, prevRoll;
        float scaleX, scaleY, scaleZ;

        const string basic = "Switch to \n ProBuilder view?";
        const string pb = "Switch to \n default view";

        bool isProBuilderEnabled = false;

        private void Awake()
        {
            SwitcherText.text = basic;
            // ringAnimation.Play();
        }

        public void SetGameObject()
        {
            GameObject selectedObject = SceneObjectController.instance.GetSelectedObject();
            if (selectedObject != null)
            {
                PosX.enabled = true;
                PosY.enabled = true;
                PosZ.enabled = true;
                ScaleX.enabled = true;
                ScaleY.enabled = true;
                ScaleZ.enabled = true;
                Roll.enabled = true;
                Pitch.enabled = true;
                Yaw.enabled = true;

                PosX.text = selectedObject.transform.position.x.ToString();
                PosY.text = selectedObject.transform.position.y.ToString();
                PosZ.text = selectedObject.transform.position.z.ToString();
                RotX.text = selectedObject.transform.rotation.x.ToString();
                RotY.text = selectedObject.transform.rotation.y.ToString();
                RotZ.text = selectedObject.transform.rotation.z.ToString();
                ScaleX.text = selectedObject.transform.localScale.x.ToString();
                ScaleY.text = selectedObject.transform.localScale.y.ToString();
                ScaleZ.text = selectedObject.transform.localScale.z.ToString();
            }
            else
            {
                PosX.enabled = false;
                PosY.enabled = false;
                PosZ.enabled = false;
                ScaleX.enabled = false;
                ScaleY.enabled = false;
                ScaleZ.enabled = false;
                Roll.enabled = false;
                Pitch.enabled = false;
                Yaw.enabled = false;
            }
        }

        public void SetTransform()
        {
            GameObject selectedObject = SceneObjectController.instance.GetSelectedObject();
            if (selectedObject != null)
            {
                _ = float.TryParse(PosX.text, out posX);
                _ = float.TryParse(PosY.text, out posY);
                _ = float.TryParse(PosZ.text, out posZ);

                _ = float.TryParse(Roll.text, out roll);
                _ = float.TryParse(Pitch.text, out pitch);
                _ = float.TryParse(Yaw.text, out yaw);

                if (roll != 0 && roll != prevRoll) 
                    prevRoll += roll; 
                else if (roll == 0)
                    prevRoll = 0;

                if (pitch != 0 && pitch != prevPitch) 
                    prevPitch += pitch;
                else if (pitch == 0)
                    prevPitch = 0;

                if (yaw != 0 && yaw != prevYaw)
                    prevYaw += yaw; 
                else if (yaw == 0)
                    prevYaw = 0;

                _ = float.TryParse(ScaleX.text, out scaleX);
                _ = float.TryParse(ScaleY.text, out scaleY);
                _ = float.TryParse(ScaleZ.text, out scaleZ);

                selectedObject.transform.position = new Vector3(posX, posY, posZ);

                if (Array.TrueForAll(new float[] { pitch, yaw, roll}, val => val == 0))
                {
                    selectedObject.transform.rotation = Quaternion.identity;

                    RotX.text = pitch != 0 ? prevPitch.ToString() : "0";
                    RotY.text = yaw != 0 ? prevYaw.ToString() : "0";
                    RotZ.text = roll != 0 ? prevRoll.ToString() : "0";
                }
                //else
                //{
                    selectedObject.transform.Rotate(pitch, yaw, roll);
                    RotX.text = prevPitch.ToString();
                    RotY.text = prevYaw.ToString();
                    RotZ.text = prevRoll.ToString();
                //}

                selectedObject.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            }
        }

        public void EnableFreeView()
        {
            if (isProBuilderEnabled == false)
            {
                isProBuilderEnabled = true;
                SwitcherText.text = pb;

                camAnimator.SetBool("isRotated", isProBuilderEnabled);
            }
            else
            {
                isProBuilderEnabled = false;
                SwitcherText.text = basic;
                camAnimator.SetBool("isRotated", isProBuilderEnabled);
            }
        }
    }
}