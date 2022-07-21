using UnityEngine;
using TMPro;


namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI healthText;
        Health health;
        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }
        private void Update()
        {
            healthText.text = string.Format("{0}%", health.GetPercentage());
        }
    }

}