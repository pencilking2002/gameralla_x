using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Utilities {

	public static Vector3 RandomVector3{
		get { return new Vector3(Random.value, Random.value, Random.value); }
	}
	public static Vector2 RandomVector2{
		get { return new Vector2(Random.value, Random.value); }
	}

	public static Vector3 RandomVector3Range(float min, float max){
		return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
	}

	public static Color ColorSmoothStep(Color from, Color to, float t){
		//float r = from.r; float g = from.g; float b = from.b; float a = from.a;
		float r = Mathf.SmoothStep(from.r, to.r, t);
		float g = Mathf.SmoothStep(from.g, to.g, t);
		float b = Mathf.SmoothStep(from.b, to.b, t);
		float a = Mathf.SmoothStep(from.a, to.a, t);
		return new Color(r, g, b, a);
	}
	public static Vector4 Vector4SmoothDampUnScaled(Vector4 current, Vector4 target, ref Vector4 velocity, float smoothTime){
		Vector4 ans = Vector4.zero;
		ans.x = Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
		ans.y = Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
		ans.z = Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
		ans.w = Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
		return ans;
	}

	public static Vector4 Vector4SmoothDamp(Vector4 current, Vector4 target, ref Vector4 velocity, float smoothTime){
		Vector4 ans = Vector4.zero;
		ans.x = Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime);
		ans.y = Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime);
		ans.z = Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime);
		ans.w = Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime);
		return ans;
	}

	public static Vector4 Vector4SmoothDamp(Vector4 current, Vector4 target, ref float velocity, float smoothTime){
		bool magGreater = (target.magnitude > current.magnitude);
		float acceleration = Mathf.Abs((target-current).magnitude) / (smoothTime*smoothTime / 4);
		velocity += acceleration;
		float maxvelocity = Mathf.Abs((target-current).magnitude / smoothTime);
		if (velocity > maxvelocity) velocity = maxvelocity;
		Vector4 endPos = Vector4.MoveTowards(current, target, velocity * Time.deltaTime);
		if (magGreater){
			if (endPos.magnitude > target.magnitude){
				return target;
			}
		}
		else if (endPos.magnitude < target.magnitude){
			return target;
		}
		return endPos;
	}

	public static Vector2 Vector2SmoothStep(Vector2 from, Vector2 to, float t){
		float x = Mathf.SmoothStep(from.x, to.x, t);
		float y = Mathf.SmoothStep(from.y, to.y, t);
		return new Vector2(x, y);
	}

	public static Vector3 ConvertV2xy(Vector2 point){
		return new Vector3(point.x, point.y, .25f);
	}

	public static Vector3 ConvertV2xz(Vector2 point){
		return new Vector3(point.x, .25f, point.y);
	}
	public static Vector2 ConvertV3xz(Vector3 point){
		return new Vector2(point.x, point.z);
	}

	public static float Vector2Cross(Vector2 p1, Vector2 p2) {
		return p1.x * p2.y - p1.y * p2.x;
	}

	public static Rect CenterRect(Vector2 center, float width, float height){
		return new Rect(
			center.x-width/2,
			center.y-height/2,
			width, height);
	}

	public static Vector3 SwapYZ(Vector3 vector){
		return new Vector3(vector.x, vector.z, vector.y);
	}
	public static void Shuffle<T>(this IList<T> list)  
	{  
	    System.Random rng = new System.Random();  
	    int n = list.Count;  
	    while (n > 1) {  
	        n--;  
	        int k = rng.Next(n + 1);  
	        T value = list[k];  
	        list[k] = list[n];  
	        list[n] = value;  
	    }  
	}


	public static void SetActiveRecursively(GameObject rootObject, bool active)
        {
            rootObject.SetActive(active);
            foreach (Transform childTransform in rootObject.transform)
            {
                SetActiveRecursively(childTransform.gameObject, active);
            }
        }

	public static string SplitCamelCase( this string str )
{
    return Regex.Replace( 
        Regex.Replace( 
            str, 
            @"(\P{Ll})(\P{Ll}\p{Ll})", 
            "$1 $2" 
        ), 
        @"(\p{Ll})(\P{Ll})", 
        "$1 $2" 
    );
}

	public static Color SaturateColor(Color color, float change) {

		float R = color.r;
		float G = color.g;
		float B = color.b;
		float A = color.a;
		
		float P=Mathf.Sqrt(
			(R)*(R)*.299f+
			(G)*(G)*.587f+
			(B)*(B)*.114f ) ;
		
		R=P+((R)-P)*change;
		G=P+((G)-P)*change;
		B=P+((B)-P)*change; 
		return new Color(R, G, B, A);
	}


	public static Color AverageColors(params Color[] colors){
		if (colors.Length < 1) return Color.black;
		if (colors.Length == 1) return colors[0];
		float r, g, b, a;
		r = g = b = a = 0;
		for(int i = 0; i < colors.Length; i++){
			r += colors[i].r;
			g += colors[i].g;
			b += colors[i].b;
			a += colors[i].a;
		}
		int count = colors.Length;
		return new Color(r/count, g/count, b/count, a/count);
	}

	public static Color AverageColors(List<Color> colors){
		if (colors.Count < 1) return Color.black;
		if (colors.Count == 1) return colors[0];
		float r, g, b, a;
		r = g = b = a = 0;
		for(int i = 0; i < colors.Count; i++){
			r += colors[i].r;
			g += colors[i].g;
			b += colors[i].b;
			a += colors[i].a;
		}
		int count = colors.Count;
		return new Color(r/count, g/count, b/count, a/count);
	}

	public static void SetMeshColors(ref Mesh mesh, Color c){
		Color[] colors = mesh.colors;
		for(int i = 0; i < colors.Length; i++){
			colors[i] = c;
		}
		mesh.colors = colors;
	}

	public static Color Saturate(this Color color, float amount){
		return SaturateColor(color, amount);
	}

}

