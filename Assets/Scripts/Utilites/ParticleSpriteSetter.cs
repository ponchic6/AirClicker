using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utilites
{
    public class ParticleSpriteSetter : MonoBehaviour
    {
        [SerializeField] private Image image;

        private void Start()
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", image.sprite.texture);
        }
    }
}
