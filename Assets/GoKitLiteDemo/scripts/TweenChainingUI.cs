using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.GoKitLite;



public class TweenChainingUI : MonoBehaviour
{
	public Transform cube;


	void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale( new Vector3( 2, 2, 2 ) );

		if( GUILayout.Button( "Tween Position Queue" ) )
		{
			GoKitLite.instance.positionTo( cube, 0.4f, new Vector3( 10, 10, 10 ) )
				.setEaseType( EaseType.QuadInOut )
				.next( 0.4f, new Vector3( 0, 0, 0 ) )
				.next( 0.4f, new Vector3( 0, -5, -10 ) )
				.next( 0.4f, new Vector3( -3, 5, 20 ) )
				.next( 0.4f, new Vector3( 0, 0, 0 ) );
		}


		if( GUILayout.Button( "Tween Position Queue with Delays" ) )
		{
			GoKitLite.instance.positionTo( cube, 0.4f, new Vector3( 10, 10, 10 ) )
				.setDelay( 0.3f )
				.setEaseType( EaseType.QuadInOut )
				.next( 0.4f, new Vector3( 0, 0, 0 ), 0.3f )
				.next( 0.4f, new Vector3( 0, -5, -10 ), 0.3f )
				.next( 0.4f, new Vector3( -3, 5, 20 ), 0.3f )
				.next( 0.4f, new Vector3( 0, 0, 0 ), 0.3f );
		}


		if( GUILayout.Button( "Tween Position and Rotation Queue" ) )
		{
			GoKitLite.instance.positionTo( cube, 0.4f, new Vector3( -8, -3, 0 ) )
				.setEaseType( EaseType.QuadInOut )
				.next( GoKitLite.TweenType.Rotation, 0.4f, new Vector3( 90f, 0, 0 ) )
				.next( GoKitLite.TweenType.Position, 0.4f, new Vector3( 1, 2, -5 ) )
				.next( GoKitLite.TweenType.Rotation, 0.4f, new Vector3( 0, 90, 90 ) )
				.next( GoKitLite.TweenType.Position, 0.4f, new Vector3( 0, 0, 0 ) )
				.next( GoKitLite.TweenType.Rotation, 0.4f, new Vector3( 360, 360, 0 ) )
				.setCompletionHandler( trans => { Debug.Log( "Position and Rotation Queue Done" ); } );
		}


		if( GUILayout.Button( "Lots of Stuff Queue" ) )
		{
			GoKitLite.instance.positionTo( cube, 0.4f, new Vector3( -8, -3, 0 ) )
				.setEaseType( EaseType.QuadInOut )
				.next( 0.3f, Color.red )
				.next( GoKitLite.TweenType.Position, 0.4f, new Vector3( 1, 2, -5 ) )
				.next( GoKitLite.TweenType.Rotation, 0.4f, new Vector3( 0, 90, 90 ) )
				.next( 0.3f, Color.yellow )
				.next( GoKitLite.TweenType.Scale, 0.8f, new Vector3( 3, 3, 3 ) )
				.setEaseType( EaseType.Punch )
				.next( GoKitLite.TweenType.Position, 0.4f, new Vector3( 0, 0, 0 ) )
				.next( 0.3f, Color.blue )
				.next( GoKitLite.TweenType.Rotation, 0.4f, new Vector3( 360, 360, 0 ), true )
				.next( GoKitLite.TweenType.Scale, 0.8f, new Vector3( 4f, 0.2f, 0.2f ) )
				.setEaseType( EaseType.BounceOut )
				.setLoopType( GoKitLite.LoopType.PingPong, 1 )
				.next( 1.3f, Color.gray, "_Color" )
				.setDelay( 0.2f );
		}
	}
}