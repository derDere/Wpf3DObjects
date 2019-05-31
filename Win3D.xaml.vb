Imports System.Windows.Media.Media3D

Public Class Win3D

    Private camController As OrbitingCameraController

    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        viewport3D1.Children.Add(New CubePillar(New Point3D(0, 0, 0), 1.5))

        camController = New OrbitingCameraController(viewport3D1, camMain)
    End Sub

End Class

Public Class OrbitingCameraController

    Private ViewParent As Panel
    Private View As Viewport3D
    Private Cam As ProjectionCamera
    Private rotaHelper As New RotationHelper

    Public Property ZoomStep As Double = 0.2D
    Public Property MoveStep As Double = 0.1D

    Private IsRotatingCam As Boolean = False
    Private IsMovingCam As Boolean = False
    Private MousePos As New Point

    Public Sub New(view As Viewport3D)
        'Set View ==========================================
        Me.View = view

        'Make Cam ==========================================
        Me.Cam = New PerspectiveCamera With {.Position = New Point3D(0, 5, 5), .LookDirection = New Vector3D(0, -5, -5)}
        Me.View.Camera = Me.Cam

        'Init ==========================================
        Init()
    End Sub

    Public Sub New(view As Viewport3D, cam As ProjectionCamera)
        'Set View ==========================================
        Me.View = view

        'Set Cam ==========================================
        Me.Cam = cam

        'Init ==========================================
        Init()
    End Sub

    Private Sub Init()
        If TypeOf View.Parent Is Panel Then
            ViewParent = View.Parent
        End If

        AddHandler ViewParent.MouseDown, AddressOf ViewPort_MouseDown
        AddHandler ViewParent.MouseUp, AddressOf ViewPort_MouseUp
        AddHandler ViewParent.MouseMove, AddressOf ViewPort_MouseMove
        AddHandler ViewParent.MouseWheel, AddressOf ViewPortMouseWheel

        AddHandler ViewParent.PreviewMouseDown, AddressOf ViewPort_MouseDown
        AddHandler ViewParent.PreviewMouseUp, AddressOf ViewPort_MouseUp
        AddHandler ViewParent.PreviewMouseMove, AddressOf ViewPort_MouseMove
        AddHandler ViewParent.PreviewMouseWheel, AddressOf ViewPortMouseWheel

        Dim r As RotationHelper.Result = rotaHelper.getPos
        Cam.Position = r.position
        Cam.LookDirection = r.viewAngle
    End Sub

    Private Sub ViewPort_MouseDown(sender As Object, e As MouseEventArgs)
        Dim curMp As Point = e.GetPosition(View)
        MousePos = New Point(curMp.X, curMp.Y)

        If e.LeftButton = MouseButtonState.Pressed Then
            IsRotatingCam = True
            ViewParent.CaptureMouse()

        ElseIf e.RightButton = MouseButtonState.Pressed Then
            IsMovingCam = True
            ViewParent.CaptureMouse()

        ElseIf e.MiddleButton = MouseButtonState.Pressed Then
        End If
    End Sub

    Private Sub ViewPort_MouseUp(sender As Object, e As MouseEventArgs)
        IsRotatingCam = False
        IsMovingCam = False
        ViewParent.ReleaseMouseCapture()
    End Sub

    Private Sub ViewPort_MouseMove(sender As Object, e As MouseEventArgs)
        If IsRotatingCam Or IsMovingCam Then
            Dim curMp As Point = e.GetPosition(View)
            Dim xD As Double = curMp.X - MousePos.X
            Dim yD As Double = curMp.Y - MousePos.Y

            If IsRotatingCam Then
                rotaHelper.H_Angle -= (xD / 8)
                rotaHelper.V_Angle -= (yD / 8)
                Dim r As RotationHelper.Result = rotaHelper.getPos
                Cam.Position = r.position
                Cam.LookDirection = r.viewAngle

            ElseIf IsMovingCam Then
                Dim OffStep As Point
                OffStep = RotationHelper.DegreesToXY(rotaHelper.H_Angle - 90, xD / 30, New Point(rotaHelper.OffsetX, rotaHelper.OffsetZ))
                OffStep = RotationHelper.DegreesToXY(rotaHelper.H_Angle + 180, yD / 30, OffStep)
                rotaHelper.OffsetX = OffStep.X
                rotaHelper.OffsetZ = OffStep.Y
                Dim r As RotationHelper.Result = rotaHelper.getPos
                Cam.Position = r.position
                Cam.LookDirection = r.viewAngle
            End If

            MousePos = New Point(curMp.X, curMp.Y)
        End If
    End Sub

    Private Sub ViewPortMouseWheel(sender As Object, e As MouseWheelEventArgs)
        If e.Delta > 0 Then
            rotaHelper.Distance += ZoomStep
            Dim r As RotationHelper.Result = rotaHelper.getPos
            Cam.Position = r.position
            Cam.LookDirection = r.viewAngle
        ElseIf e.Delta < 0 Then
            rotaHelper.Distance -= ZoomStep
            Dim r As RotationHelper.Result = rotaHelper.getPos
            Cam.Position = r.position
            Cam.LookDirection = r.viewAngle
        End If
    End Sub

    Private Class RotationHelper
        Public Structure Result
            Public position As Point3D
            Public viewAngle As Vector3D
        End Structure

        Private _V_Angle As Double = -45
        Public Property V_Angle As Double
            Get
                Return _V_Angle
            End Get
            Set(value As Double)
                If value > 0 Then value = 0
                If value < -90 Then value = -90
                _V_Angle = value
            End Set
        End Property

        Private _H_Angle As Double = 45
        Public Property H_Angle As Double
            Get
                Return _H_Angle
            End Get
            Set(value As Double)
                value = value Mod 360
                If value < 0 Then value += 360
                _H_Angle = value
            End Set
        End Property

        Public Property Distance As Double = 10

        Public Property OffsetX As Double = 0
        Public Property OffsetY As Double = 0
        Public Property OffsetZ As Double = 0

        Public Function getPos() As Result

            Dim XY As Point = DegreesToXY(V_Angle, Distance, New Point(0, 0))
            Dim XZ As Point = DegreesToXY(H_Angle, XY.X, New Point(0, 0))

            Dim r As New Result() With {
                .position = New Point3D(XZ.X + OffsetX, XY.Y + OffsetY, XZ.Y + OffsetZ),
                .viewAngle = New Vector3D(-XZ.X, -XY.Y, -XZ.Y)
            }

            Return r
        End Function

        Public Shared Function DegreesToXY(ByVal degrees As Single, ByVal radius As Single, ByVal origin As Point) As Point
            Dim xy As Point = New Point()
            Dim radians As Double = degrees * Math.PI / 180.0
            xy.X = CSng(Math.Cos(radians)) * radius + origin.X
            xy.Y = CSng(Math.Sin(-radians)) * radius + origin.Y
            Return xy
        End Function

        Public Shared Function XYToDegrees(ByVal xy As Point, ByVal origin As Point) As Single
            Dim deltaX As Integer = origin.X - xy.X
            Dim deltaY As Integer = origin.Y - xy.Y
            Dim radAngle As Double = Math.Atan2(deltaY, deltaX)
            Dim degreeAngle As Double = radAngle * 180.0 / Math.PI
            Return CSng((180.0 - degreeAngle))
        End Function

    End Class

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
