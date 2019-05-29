Class MainWindow 

    Public Property Personal As Person()

    Private _Liste As String
    Public Property NewProperty() As String
        Get
            Return _Liste
        End Get
        Set(ByVal value As String)
            _Liste = value
        End Set
    End Property


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        MsgBox("Ho Ho Ho")
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim L As New List(Of Person)

        L.Add(New Person With {.Name = "Peter", .Alter = 12})
        L.Add(New Person With {.Name = "Micha", .Alter = 59})
        L.Add(New Person With {.Name = "Phillip", .Alter = 26})
        L.Add(New Person With {.Name = "Max", .Alter = 3})

        Me.Personal = L.ToArray

        ic.GetBindingExpression(ItemsControl.DataContextProperty).UpdateTarget()
    End Sub

    Private Sub MainWindow_MouseWheel(sender As Object, e As MouseWheelEventArgs) Handles Me.MouseWheel
        If e.Delta < 0 Then
            WinScale.ScaleX += 0.1D
            WinScale.ScaleY += 0.1D
        Else
            WinScale.ScaleX -= 0.1D
            WinScale.ScaleY -= 0.1D
        End If
    End Sub

    Private Sub Hyperlink_Click(sender As Object, e As RoutedEventArgs)
        If TypeOf sender Is Hyperlink Then
            Dim hl As Hyperlink = sender
            Process.Start(hl.NavigateUri.ToString)
        End If
    End Sub

    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Dim l As Double = 1884.884135
        Dim str As String = l.ToString("#,##0")
        'Stop
    End Sub

End Class


Public Class Person
    Public Property Name As String
    Public Property Alter As Integer
End Class