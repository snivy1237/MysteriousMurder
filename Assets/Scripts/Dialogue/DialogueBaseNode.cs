﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueBaseNode : Node {

	[Input] public DialogueBaseNode prev;
	[Output] public DialogueBaseNode next;

	[TextArea]
	public string text;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}