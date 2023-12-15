using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Canek
{
    public class CameraMove_Canek : MonoBehaviour
    {
        private float movX;
        private float movY;

        public float moveSenseY;
        public float moveSenseX;

        public bool invertYAxis;

        public Transform personaje;

        private float rotX = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            personaje = transform.parent;
        }

        // Update is called once per frame
        void Update()
        {
            movX = Input.GetAxis("Mouse X") * moveSenseX * Time.deltaTime;
            movY = Input.GetAxis("Mouse Y") * moveSenseY * Time.deltaTime;

            if (invertYAxis)
            {
                rotX += movY;
            }
            else
            {
                rotX -= movY;
            }


            rotX = Mathf.Clamp(rotX, -90f, 90f);

            personaje.Rotate(0, movX, 0);
            transform.localRotation = Quaternion.Euler(rotX, 0, 0);
}       }
    }
