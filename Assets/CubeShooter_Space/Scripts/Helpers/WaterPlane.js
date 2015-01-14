     
    //------------------------------//
    //  WaterPlane.js               //
    //  Written by Alucard Jay      //
    //  6/21/2013                   //
    //------------------------------//
     
    #pragma strict
    @script RequireComponent( MeshFilter, MeshRenderer )
     
    var waterWidth : float = 20.0; // width of the water plane
    var waterHeight : float = 10.0; // average height of the water plane
    var waveHeight : float = 2.0; // how far the wave is above and below waterHeight
    var waveSpeed : float = 5.0; // how fast the waves move
    var waveFrequency : float = 1.0; // how many waves (peaks)
     
    var accuracy : int = 20; // mesh resolution
     
    private var mesh : Mesh;
     
    private var verts : Vector3[];
    private var uvs : Vector2[];
    private var tris : int[];
     
     
    function Start()
    {
        ConstructMesh();
    }
     
     
    function Update()
    {
        UpdateWaves();
    }
     
     
    function UpdateWaves()
    {
        var offset : float;
       
        for ( var i : int = 0; i < accuracy; i ++ )
        {
            offset = waveHeight * Mathf.Sin( ( Time.time * waveSpeed ) + ( i * waveFrequency ) );
           
            verts[ i ].y = waterHeight + offset;
        }
       
        mesh.vertices = verts;
    }
     
     
    function ConstructMesh()
    {
        // - initialize arrays -
        verts = new Vector3[ accuracy * 2 ];
        uvs = new Vector2[ accuracy * 2 ];
        tris = new int[ ( accuracy - 1 ) * 12 ];
       
        // - store reference to mesh -
        mesh = new Mesh();
        GetComponent( MeshFilter ).mesh = mesh;
       
        // - calculate vertices and uvs -
        var spacing : float = waterWidth / parseFloat( accuracy - 1 );
        var uvX : float;
       
        for ( var i : int = 0; i < accuracy; i ++ )
        {
            verts[ i ] = new Vector3( i * spacing, waterHeight, 0 );
            verts[ i + accuracy ] = new Vector3( i * spacing, 0, 0 );
           
            uvX = ( i * spacing ) / waterWidth;
            uvs[ i ] = new Vector2( uvX, 1.0 );
            uvs[ i + accuracy ] = new Vector2( uvX, 0.0 );
        }
       
        // - calculate triangles -
        var index : int = 0;
       
        for ( i = 0; i < accuracy - 1; i ++ )
        {
            tris[ index + 0 ] = i;
            tris[ index + 1 ] = i + 1;
            tris[ index + 2 ] = i + accuracy;
           
            tris[ index + 3 ] = i + accuracy;
            tris[ index + 4 ] = i + 1;
            tris[ index + 5 ] = i + accuracy + 1;
           
            index += 6;
        }
       
        // - assign values to mesh -
       
        mesh.name = "Water2D_Plane_Mesh";
       
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = tris;
       
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
     
