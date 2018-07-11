Imports MySql.Data.MySqlClient
Public Class Form2

    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim b As String
    Public Sub New(ByVal a As String)
        b = a
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 616
        Me.Width = 1172
        Me.CenterToScreen()

        myConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=root;" _
            & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =" & b, conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt1 As New DataTable()
                        sda.Fill(dt1)
                        MsgBox(dt1.ToString, MsgBoxStyle.Exclamation, "Process Complete")

                        datagrid2.DataSource = dt1
                        datagrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill




                    End Using
                End Using
            End Using
        End Using
    End Sub



    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub
End Class