using UnityEngine;

namespace Support
{
    /// <summary>
    /// Class for rotating objects
    /// </summary>
    public class ObjectRotator : MonoBehaviour
    {
        public Vector3 rotationDirectionalSpeed;
        public float bobbingSpeed;
        public float bobbingOffset;

        private void Update()
        {
            var localRotation = transform.localRotation;
            var targetRotation = Quaternion.Euler(rotationDirectionalSpeed) * localRotation;
               
            localRotation = Quaternion.Lerp(localRotation, targetRotation, Time.deltaTime);
            transform.localRotation = localRotation;

            transform.localPosition += Vector3.up * (Mathf.Sin(Time.time * bobbingSpeed) * bobbingOffset * Time.deltaTime);
        }
    }
}