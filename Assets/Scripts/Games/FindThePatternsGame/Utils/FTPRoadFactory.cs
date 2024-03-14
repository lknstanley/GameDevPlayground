using System.Collections.Generic;
using Games.FindThePatternsGame.Constraints;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Games.FindThePatternsGame
{
    public class FTPRoadFactory
    {
        public static FTPRoad CreateRoad( GameObject template, Vector3 pos, Vector3 size, Transform container,
            FTPRoadType type )
        {
            var go = Object.Instantiate( template, container );
            var road = go.GetComponent< FTPRoad >();
            road.Initialise( pos, size, type );
            return road;
        }

        /// <summary>
        ///     Populate 3D models to the game scene based on the road map data
        /// </summary>
        /// <param name="map"></param>
        /// <param name="template"></param>
        /// <param name="container"></param>
        public static void PopulateRoadMap( List< List< int > > map, GameObject template, Transform container,
            out List< Transform > roadTrans )
        {
            // Initialise road transform list
            roadTrans = new List< Transform >();

            for ( var i = 0; i < map.Count; i++ )
            {
                var row = map[ i ];
                for ( var j = 0; j < row.Count; j++ )
                {
                    var item = ( FTPRoadType ) row[ j ];
                    var pos = new Vector3( j, 0, i );
                    var size = Vector3.one;
                    FTPRoad road = null;
                    switch ( item )
                    {
                        case FTPRoadType.Walkable:
                            road = CreateRoad( template, pos, size, container, item );
                            break;
                        case FTPRoadType.NotWalkable:
                            pos += Vector3.up * 1f;
                            road = CreateRoad( template, pos, size, container, item );
                            break;
                        case FTPRoadType.Entrance:
                            road = CreateRoad( template, pos, size, container, item );
                            break;
                        case FTPRoadType.Goal:
                            road = CreateRoad( template, pos, size, container, item );
                            break;
                    }

                    if ( road != null )
                        roadTrans.Add( road.transform );
                }
            }
        }

        /// <summary>
        ///     Generate road map data randomly
        /// </summary>
        /// <param name="width">Map width</param>
        /// <param name="height">Map height</param>
        /// <param name="map">Shuffled map</param>
        public static void ShuffleRoadMap( int width, int height, out List< List< int > > map )
        {
            // Initialise all item to 0 as default
            // 0 - walkable
            // 1 - not walkable
            // 2 - entrance
            // 3 - goal
            map = new List< List< int > >();
            for ( var i = 0; i < height; i++ )
            {
                var list = new List< int >();
                for ( var j = 0; j < width; j++ )
                    if ( i == 0 || i == height - 1 || j == 0 || j == width - 1 )
                    {
                        list.Add( 1 );
                    }
                    else
                    {
                        // Only generate walkable one step closer to the entrance and exit
                        if ( i == 1 || j == 1 || i == height - 2 || j == width - 2 )
                        {
                            list.Add( 0 );
                        }
                        else
                        {
                            // Randomly generate workable or not walkable
                            var rand = Random.Range( 0, 100 );
                            list.Add( rand <= 60 ? 0 : 1 );
                        }
                    }

                map.Add( list );
            }

            // Set entrance at the left side randomly
            var entranceIndex = Random.Range( 1, height - 1 );
            map[ entranceIndex ][ 0 ] = 2;

            // Set goal at the right side randomly
            var goalIndex = Random.Range( 1, height - 1 );
            map[ goalIndex ][ width - 1 ] = 3;

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