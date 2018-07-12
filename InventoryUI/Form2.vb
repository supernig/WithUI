Imports MySql.Data.MySqlClient
Public Class Form2


    Dim b As String
    Public Sub New(ByVal a As String)
        b = a
    End Sub
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 616
        Me.Width = 1172
        Me.CenterToScreen()

        MsgBox(b, MsgBoxStyle.Exclamation, "Process Complete")
        myConnectionString = "server=127.0.0.1;" _
           & "uid=root;" _
           & "pwd=root;" _
           & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =" + b, conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        BunifuCustomDataGrid1.DataSource = dt
                        BunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                        BunifuCustomDataGrid1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        BunifuCustomDataGrid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        BunifuCustomDataGrid1.Columns(0).HeaderCell.Value = "Action"
                        BunifuCustomDataGrid1.Columns(1).HeaderCell.Value = "ID"
                        BunifuCustomDataGrid1.Columns(2).HeaderCell.Value = "Item Name"
                        BunifuCustomDataGrid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



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

    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class