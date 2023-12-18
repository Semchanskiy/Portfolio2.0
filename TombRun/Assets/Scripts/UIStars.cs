using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStars : MonoBehaviour
{
    [SerializeField] private GameObject OneStar;
    [SerializeField] private GameObject TwoStar;
    [SerializeField] private GameObject ThreeStar;
    [SerializeField] private Sprite _star;

    public void AddStar(float count)
    {
        if(count == 1)
        {
            OneStar.GetComponent<Image>().sprite = _star;
        }
        else if(count == 2)
        {
            TwoStar.GetComponent<Image>().sprite = _star;
        }
        else if (count == 3)
        {
            ThreeStar.GetComponent<Image>().sprite = _star;
        }
    }
}
