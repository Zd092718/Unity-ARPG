using UnityEngine;
using TMPro;
using RPG.Stats;

namespace RPG.Attributes
{
    public class ExperienceDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI xpText;

        Experience experience;


        Health health;
        private void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }
        private void Update()
        {
            xpText.text = experience.GetExperience().ToString();
        }

    }

}