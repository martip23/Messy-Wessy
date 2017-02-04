using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
	
	public int frameRange = 60;
	public int AverageFPS { get; private set; }
	public int HighestFPS { get; private set; }
	public int LowestFPS  { get; private set; }

	int [] fpsBuffer;
	int fpsBufferIndex;

	// Initialize buffer. No values < 1. Create list frameRange long.
	// Start index @ 0
	void InitializeBuffer () {
		if (frameRange <= 0) {
			frameRange = 1;
		}
		fpsBuffer = new int[frameRange];
		fpsBufferIndex = 0;
	}

	// Start buffer if null or if frameRange changed.
	void Update () {
		if (fpsBuffer == null || fpsBuffer.Length != frameRange) {
			InitializeBuffer ();
		}
		UpdateBuffer ();
		CalculateFPS ();
	}

	// Add values to list. Reset index to 0 if index > frameRange
	void UpdateBuffer () {
		fpsBuffer [fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
		if (fpsBufferIndex >= frameRange) {
			fpsBufferIndex = 0;
		}
	}

	// Get the average by adding all & subbing by buffer size
	void CalculateFPS(){
		int highest = 0;
		int lowest = int.MaxValue;
		int sum = 0;
		for (int i = 0; i < frameRange; i++){
			int fps = fpsBuffer [i];
			if (fps > highest) {
				highest = fps;
			}
			if (fps < lowest) {
				lowest = fps;
			}
			sum += fpsBuffer [i];
		}
		AverageFPS = sum / frameRange;
		HighestFPS = highest;
		LowestFPS = lowest;
	}
}
