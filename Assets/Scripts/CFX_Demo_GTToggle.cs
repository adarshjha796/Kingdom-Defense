using System;
using UnityEngine;

public class CFX_Demo_GTToggle : MonoBehaviour
{
	public Texture Normal;

	public Texture Hover;

	public Color NormalColor = new Color32(128, 128, 128, 128);

	public Color DisabledColor = new Color32(128, 128, 128, 48);

	public bool State = true;

	public string Callback;

	public GameObject Receiver;

	private Rect CollisionRect;

	private bool Over;

	private GUIText Label;

	private void Awake()
	{
		this.CollisionRect = base.GetComponent<GUITexture>().GetScreenRect(Camera.main);
		this.Label = base.GetComponentInChildren<GUIText>();
		this.UpdateTexture();
	}

	private void Update()
	{
		if (this.CollisionRect.Contains(UnityEngine.Input.mousePosition))
		{
			this.Over = true;
			if (Input.GetMouseButtonDown(0))
			{
				this.OnClick();
			}
		}
		else
		{
			this.Over = false;
			base.GetComponent<GUITexture>().color = this.NormalColor;
		}
		this.UpdateTexture();
	}

	private void OnClick()
	{
		this.State = !this.State;
		this.Receiver.SendMessage(this.Callback);
	}

	private void UpdateTexture()
	{
		Color color = (!this.State) ? this.DisabledColor : this.NormalColor;
		if (this.Over)
		{
			base.GetComponent<GUITexture>().texture = this.Hover;
		}
		else
		{
			base.GetComponent<GUITexture>().texture = this.Normal;
		}
		base.GetComponent<GUITexture>().color = color;
		if (this.Label != null)
		{
			this.Label.color = color * 1.75f;
		}
	}
}
