using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    public TMP_Dropdown idiomaDropdown;
    public GameObject temaDropdown;
    public GameObject temaDropdownEn;
    public void Update()
    {
        string code = idiomaDropdown.options[idiomaDropdown.value].text;
        // 1
        var localeQuery = (from locale in LocalizationSettings.AvailableLocales.Locales
                           where locale.Identifier.Code == code
                           select locale).FirstOrDefault();

        // 2
        if (localeQuery == null)
        {
            Debug.LogError($"No locale for {code} found");
            return;
        }

        // 3
        LocalizationSettings.SelectedLocale = localeQuery;
        if (code == "es")
        {
            temaDropdown.SetActive(true);
            temaDropdownEn.SetActive(false);
        }
        else
        {
            temaDropdown.SetActive(false);
            temaDropdownEn.SetActive(true);
        }
    }

}
