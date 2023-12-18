using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private BallMovement BallMovement;
    private Vector2 fixedPosition = Vector2.zero;
    public float TapRange
    {
        get { return _tapRange; }
        set { _tapRange = Mathf.Abs(value); }
    }

    public float DieZone
    {
        get { return dieZone; }
        set { dieZone = Mathf.Abs(value); }
    }

    [SerializeField] private float _tapRange = 1;
    [SerializeField] private float dieZone = 0;


    [SerializeField] private RectTransform backgrounds = null;
    [SerializeField] private RectTransform handle = null;
    private RectTransform Rectbase = null;

    private Canvas canvas;
    public Camera cam;

    private Vector2 input = Vector2.zero;

    private void Start()
    {

        TapRange = _tapRange;
        DieZone = dieZone;
        Rectbase = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        Vector2 center = new Vector2(0.5f, 0.5f);
        backgrounds.pivot = center;
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        handle.anchoredPosition = Vector2.zero;

        fixedPosition = backgrounds.anchoredPosition;
        backgrounds.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgrounds.transform.position = Input.mousePosition;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        backgrounds.gameObject.SetActive(true);
        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, backgrounds.position);
        Vector2 localPoint = Vector2.zero;

        Vector2 radius = backgrounds.sizeDelta;
        input = (eventData.position - position) / (radius * canvas.scaleFactor);

        InputHandle(input.magnitude, input.normalized, radius, cam);

        handle.anchoredPosition = input * radius * _tapRange / 2;

    }

    private void FixedUpdate()
    {
        BallMovement.AddForce(input);
    }

    private void InputHandle(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > dieZone)
        {
            if (magnitude > 1)
                input = normalised;
        }
        else
            input = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        backgrounds.gameObject.SetActive(false);
    }
}
