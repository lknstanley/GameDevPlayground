using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Games.FindThePatternsGame
{
    public class FTPRoadFactory
    {
        public static FTPRoad CreateRoad( GameObject template, Vector3 pos, Vector3 size, Transform container )
        {
            var go = Object.Instantiate( template, container );
            var road = go.GetComponent< FTPRoad >();
            road.Initialise( pos, size );
            return road;
        }

        public static void ShuffleRoadMap( int width, int height, out List< List< int > > map )
        {
            // Initialise all item to 0 as default
            // 0 - walkable
            // 1 - not walkable
            map = new List< List< int > >();
            for ( var i = 0; i < height; i++ )
            {
                var list = new List< int >();
                for ( var j = 0; j < width; j++ )
                    if ( i == 0 || i == height - 1 || j == 0 || j == width - 1 )
                        list.Add( 1 );
                    else
                        list.Add( 0 );
                map.Add( list );
            }

            PrintMap( map );
        }

        public static void PrintMap( List< List< int > > map )
        {
            for ( var i = 0; i < map.Count; i++ )
            {
                var row = map[ i ];
                Debug.Log( $"[FTPRoadFactory] {string.Join( ",", row )}" );
            }
        }
    }
}