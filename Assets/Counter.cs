using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private bool _isActivated;
    private float _delay;
    private IEnumerator _coroutine;

    private void Start()
    {
        DisplayNumber(0);

        _isActivated = false;
        _delay = 0.5f;
        _coroutine = Count(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActivated = !_isActivated;

            if(_isActivated == true)
            {
                StartCoroutine(_coroutine);
            }
            else
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator Count(float delay)
    {
        int countedNumber = 0;

        while(true) 
        {
            yield return new WaitForSeconds(delay);

            countedNumber++;
            DisplayNumber(countedNumber);
        }
    }

    private void DisplayNumber(int number)
    {
        _text.text = number.ToString();
    }
}
