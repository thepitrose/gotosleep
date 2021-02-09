Public Class Form1

    Private getTime As String
    Private TargetDT As DateTime
    Private TargetDTT As DateTime

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Timer1.Interval = 100
        getTime = TextBox1.Text
        Dim sTime As Integer
        sTime = getTime
        Dim Countdown As TimeSpan = TimeSpan.FromMinutes(sTime)

        TargetDT = DateTime.Now.Add(Countdown)

        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("hh\:mm\:ss")


        Else
            Timer1.Stop()
            Label1.Text = "00:00"
            KillHungProcess("chrome.exe") 'Put your process name here

        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Public Sub KillHungProcess(processName As String)
        Dim psi As ProcessStartInfo = New ProcessStartInfo
        psi.Arguments = "/im " & processName & " /f"
        psi.FileName = "taskkill"
        Dim p As Process = New Process()
        p.StartInfo = psi
        p.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Timer2.Interval = 100
        getTime = TextBox1.Text
        Dim sTime As Integer
        sTime = getTime
        Dim Countdown As TimeSpan = TimeSpan.FromMinutes(sTime)
        TargetDTT = DateTime.Now.Add(Countdown)
        Timer2.Start()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim ts As TimeSpan = TargetDTT.Subtract(DateTime.Now)
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("hh\:mm\:ss")

        Else
            Timer1.Stop()
            Label1.Text = "00:00"
            Process.Start("shutdown", "-s")

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
