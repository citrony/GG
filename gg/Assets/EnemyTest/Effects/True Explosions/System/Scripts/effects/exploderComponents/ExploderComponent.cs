using UnityEngine;
using System.Collections;

public abstract class ExploderComponent : MonoBehaviour {
	public abstract void onExplosionStarted(ExploderT exploder);
	void Start() {
		// is needed to have the ability to disable the components
	}
}
