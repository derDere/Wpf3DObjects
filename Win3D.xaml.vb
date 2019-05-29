Imports System.Windows.Media.Media3D

Public Class Win3D


    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        viewport3D1.Children.Add(New CubePillar(New Point3D(0, 0, 0), 1.5))
    End Sub

End Class

Public Class CubePillar
    Inherits ModelVisual3D

    Public Enum FloorTypes
        Solid
        Water
        Lava
    End Enum

    Public Shared Property LineMaterial As New EmissiveMaterial(New SolidColorBrush(Color.FromArgb(128, 255, 255, 225)))
    Public Shared Property SolidFloorMaterial As New EmissiveMaterial(New SolidColorBrush(Color.FromArgb(255, 128, 128, 128)))
    Public Shared Property LavaFloorMaterial As New EmissiveMaterial(New SolidColorBrush(Color.FromArgb(255, 255, 80, 0)))
    Public Shared Property WaterFloorMaterial As New EmissiveMaterial(New SolidColorBrush(Color.FromArgb(255, 0, 128, 225)))

    Private _Position As Point3D
    Public Property Position As Point3D
        Get
            Return _Position
        End Get
        Set(value As Point3D)
            _Position = value
        End Set
    End Property

    Public Property Height As Double

    Public Property Wight As Double

    Public Property ShowFloor As Boolean = True

    Public Property ShowSeeling As Boolean = True

    Public Property FloorType As FloorTypes = FloorTypes.Solid

    Public Sub New(Pos As Point3D, Height As Double, Optional Wight As Double = 1D)
        Me._Position = Pos
        Me._Height = Height
        Me._Wight = Wight

        Contruct()
    End Sub

    Public Sub ReConstruct()
        Me.Content = Nothing
        Contruct()
    End Sub

    Private Sub Contruct()
        Dim gro As New Model3DGroup

        Dim ftl As New Point3D(Position.X, Position.Y, Position.Z + Wight)
        Dim ftr As New Point3D(Position.X + Wight, Position.Y, Position.Z + Wight)
        Dim fbl As New Point3D(Position.X, Position.Y, Position.Z)
        Dim fbr As New Point3D(Position.X + Wight, Position.Y, Position.Z)
        Dim stl As New Point3D(Position.X, Position.Y + Height, Position.Z + Wight)
        Dim str As New Point3D(Position.X + Wight, Position.Y + Height, Position.Z + Wight)
        Dim sbl As New Point3D(Position.X, Position.Y + Height, Position.Z)
        Dim sbr As New Point3D(Position.X + Wight, Position.Y + Height, Position.Z)

        gro.Children.Add(New GeometryModel3D(DrawLine(ftl, ftr), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(ftr, fbr), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(fbr, fbl), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(fbl, ftl), LineMaterial))

        gro.Children.Add(New GeometryModel3D(DrawLine(stl, str), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(str, sbr), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(sbr, sbl), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(sbl, stl), LineMaterial))

        gro.Children.Add(New GeometryModel3D(DrawLine(ftl, stl), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(ftr, str), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(fbr, sbr), LineMaterial))
        gro.Children.Add(New GeometryModel3D(DrawLine(fbl, sbl), LineMaterial))

        If ShowFloor Then
            Dim FloorMat As Material
            Select Case FloorType
                Case FloorTypes.Lava
                    FloorMat = LavaFloorMaterial
                Case FloorTypes.Water
                    FloorMat = WaterFloorMaterial
                Case Else
                    FloorMat = SolidFloorMaterial
            End Select
            gro.Children.Add(New GeometryModel3D(DrawSquare(ftl, ftr, fbr, fbl), FloorMat))
        End If

        If ShowSeeling Then _
            gro.Children.Add(New GeometryModel3D(DrawSquare(stl, str, sbr, sbl), LineMaterial))

        For Each gm As GeometryModel3D In gro.Children
            gm.BackMaterial = gm.Material
        Next

        Me.Content = gro
    End Sub

End Class
