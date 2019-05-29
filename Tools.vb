Imports System.Windows.Media.Media3D

Module Tools

    Private Const STRENGTH As Double = 0.01D

    Public Function DrawSquare(p0 As Point3D, p1 As Point3D, p2 As Point3D, p3 As Point3D) As MeshGeometry3D
        Dim meshGeo As New MeshGeometry3D()

        meshGeo.Positions.Add(p0)
        meshGeo.Positions.Add(p1)
        meshGeo.Positions.Add(p3)
        meshGeo.Positions.Add(p2)

        meshGeo.TriangleIndices.Add(0)
        meshGeo.TriangleIndices.Add(1)
        meshGeo.TriangleIndices.Add(2)

        meshGeo.TriangleIndices.Add(1)
        meshGeo.TriangleIndices.Add(2)
        meshGeo.TriangleIndices.Add(3)

        Dim normal As New Vector3D(1, 1, 1) ' = CalculateNormal(p0, p1, p2)
        normal.Normalize()
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)

        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)

        Return meshGeo
    End Function

    Public Function DrawLine(Pos1 As Point3D, Pos2 As Point3D) As MeshGeometry3D
        Dim meshGeo As New MeshGeometry3D()

        Dim p0 As New Point3D(Pos1.X, Pos1.Y, Pos1.Z)
        Dim p1 As New Point3D(Pos2.X, Pos2.Y, Pos2.Z)
        Dim p2 As New Point3D(Pos1.X + STRENGTH, Pos1.Y, Pos1.Z)
        Dim p3 As New Point3D(Pos2.X + STRENGTH, Pos2.Y, Pos2.Z)

        meshGeo.Positions.Add(p0)
        meshGeo.Positions.Add(p1)
        meshGeo.Positions.Add(p2)
        meshGeo.Positions.Add(p3)

        meshGeo.TriangleIndices.Add(0)
        meshGeo.TriangleIndices.Add(1)
        meshGeo.TriangleIndices.Add(2)

        meshGeo.TriangleIndices.Add(1)
        meshGeo.TriangleIndices.Add(2)
        meshGeo.TriangleIndices.Add(3)

        Dim normal As New Vector3D(1, 1, 1) ' = CalculateNormal(p0, p1, p2)
        normal.Normalize()
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)

        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)

        DrawLine2(meshGeo, Pos1, Pos2)

        Return meshGeo
    End Function

    Public Sub DrawLine2(ByRef meshGeo As MeshGeometry3D, Pos1 As Point3D, Pos2 As Point3D)

        Dim p0 As New Point3D(Pos1.X, Pos1.Y, Pos1.Z)
        Dim p1 As New Point3D(Pos2.X, Pos2.Y, Pos2.Z)
        Dim p2 As New Point3D(Pos1.X, Pos1.Y, Pos1.Z + STRENGTH)
        Dim p3 As New Point3D(Pos2.X, Pos2.Y, Pos2.Z + STRENGTH)

        Dim L As Integer = meshGeo.Positions.Count

        meshGeo.Positions.Add(p0)
        meshGeo.Positions.Add(p1)
        meshGeo.Positions.Add(p2)
        meshGeo.Positions.Add(p3)

        meshGeo.TriangleIndices.Add(0 + L)
        meshGeo.TriangleIndices.Add(1 + L)
        meshGeo.TriangleIndices.Add(2 + L)

        meshGeo.TriangleIndices.Add(1 + L)
        meshGeo.TriangleIndices.Add(2 + L)
        meshGeo.TriangleIndices.Add(3 + L)

        Dim normal As New Vector3D(1, 1, 1) ' = CalculateNormal(p0, p1, p2)
        normal.Normalize()
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)

        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
        meshGeo.Normals.Add(normal)
    End Sub

End Module
