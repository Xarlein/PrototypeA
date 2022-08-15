using UnityEngine.UI;
using UnityEngine;
using System;

namespace Assets.Scripts.UI
{
    public sealed class Bar : MonoBehaviour
    {
        [SerializeField]
        private Image _bar;

        public void SetValue(float value)
        {
            if (value < 0 || value > 1)
                throw new Exception("Values between 0 and 1 are acceptable!");

            _bar.fillAmount = value;
        }
    }
}
