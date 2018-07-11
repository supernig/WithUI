Imports MySql.Data.MySqlClient

Public Class Form1
    Public a As String
    Dim b As String
    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

        If a = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            Dim box = New Form2(a)
            box.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If pan1.Visible = False Then
            pan1.Visible = True

        Else
            pan1.Visible = False

        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        If a = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            tb2.Text = b

            If pan2.Visible = False Then
                pan2.Visible = True

            Else
                pan2.Visible = False

            End If


        End If
    End Sub




    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

        If a = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            Using con As New MySqlConnection(myConnectionString)
                Using cmd As New MySqlCommand("DELETE FROM items WHERE id =" + a, conn)
                    cmd.CommandType = CommandType.Text

                    If cmd.ExecuteNonQuery > 0 Then
                        MsgBox("Successfully Deleted", MsgBoxStyle.Exclamation, "Process Complete")

                        Using cmd1 As New MySqlCommand("SELECT items.id,items.name FROM items ", conn)
                            cmd1.CommandType = CommandType.Text
                            Using sda As New MySqlDataAdapter(cmd1)
                                Using dt As New DataTable()


                                    sda.Fill(dt)
                                    Dim bSource As New BindingSource()
                                    bSource.DataSource = dt
                                    BunifuCustomDataGrid1.DataSource = bSource
                                    bSource.ResetBindings(False)
                                    BunifuCustomDataGrid1.Refresh()
                                    a = Nothing
                                End Using
                            End Using
                        End Using

                    Else
                        MsgBox("Something went wrong.", MsgBoxStyle.Exclamation, "Error")



                    End If
                End Using
            End Using
        End If
    End Sub
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        myConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=root;" _
            & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name FROM items ", conn)
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

    Private Sub BunifuCustomDataGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellContentClick
        If e.ColumnIndex = BunifuCustomDataGrid1.Columns("Column1").Index Then
            DataGridViewCheckBoxColumn_Uncheck()
            Dim cell As DataGridViewCheckBoxCell = BunifuCustomDataGrid1.Rows(e.RowIndex).Cells("Column1")
            cell.Value = cell.TrueValue
            a = BunifuCustomDataGrid1.Rows(e.RowIndex).Cells(1).Value.ToString()
            b = BunifuCustomDataGrid1.Rows(e.RowIndex).Cells(2).Value.ToString()
        End If
    End Sub

    Private Sub DataGridViewCheckBoxColumn_Uncheck()
        For Each row As DataGridViewRow In BunifuCustomDataGrid1.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("Column1")
            cell.Value = cell.FalseValue
        Next
    End Sub

    Private Sub BunifuCustomLabel1_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel1.Click

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click


        Using con1 As New MySqlConnection(myConnectionString)
            Using cmd1 As New MySqlCommand("Select COUNT(*) FROM items where name ='" + tb1.Text + "'", conn)
                cmd1.CommandType = CommandType.Text

                If cmd1.ExecuteScalar > 0 Then
                    MsgBox("Item is already registered.", MsgBoxStyle.Exclamation, "Error")

                Else

                    If tb1.Text = "" Then
                        MsgBox("Inputs cannot be blank.", MsgBoxStyle.Exclamation, "Process Complete")
                    Else
                        Using con As New MySqlConnection(myConnectionString)
                            Using cmd As New MySqlCommand(" INSERT INTO `db`.`items` (`name`) VALUES ('" + tb1.Text + "');", conn)
                                cmd.CommandType = CommandType.Text

                                If cmd.ExecuteNonQuery > 0 Then
                                    MsgBox("Successfully added to database", MsgBoxStyle.Exclamation, "Process Complete")
                                    Using cmd2 As New MySqlCommand("SELECT items.id,items.name FROM items ", conn)
                                        cmd2.CommandType = CommandType.Text
                                        Using sda As New MySqlDataAdapter(cmd2)
                                            Using dt As New DataTable()
                                                sda.Fill(dt)
                                                BunifuCustomDataGrid1.DataSource = dt

                                                BunifuCustomDataGrid1.Update()

                                            End Using
                                        End Using
                                    End Using
                                    pan1.Visible = False
                                    tb1.Text = ""

                                End If
                            End Using
                        End Using
                    End If
                End If
            End Using
        End Using

    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles tb1.OnValueChanged

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        pan1.Visible = False
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        pan2.Visible = False
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click

        Using con1 As New MySqlConnection(myConnectionString)
            Using cmd1 As New MySqlCommand("Select COUNT(*) FROM items where name ='" + tb2.Text + "'", conn)
                cmd1.CommandType = CommandType.Text

                If cmd1.ExecuteScalar > 0 Then
                    MsgBox("Item is already registered.", MsgBoxStyle.Exclamation, "Error")

                Else

                    If tb2.Text = "" Then
                        MsgBox("Inputs cannot be blank.", MsgBoxStyle.Exclamation, "Process Complete")
                    Else

                        Using con As New MySqlConnection(myConnectionString)
                            Using cmd As New MySqlCommand(" UPDATE `db`.`items` SET `name`='" + tb2.Text + "' WHERE (`id` = '" & a & "');", conn)
                                cmd.CommandType = CommandType.Text

                                If cmd.ExecuteNonQuery > 0 Then
                                    MsgBox("Successfully updated in the database", MsgBoxStyle.Exclamation, "Process Complete")
                                    Using cmd2 As New MySqlCommand("SELECT items.id,items.name FROM items ", conn)
                                        cmd2.CommandType = CommandType.Text
                                        Using sda As New MySqlDataAdapter(cmd2)
                                            Using dt As New DataTable()

                                                sda.Fill(dt)
                                                Dim bSource As New BindingSource()
                                                bSource.DataSource = dt
                                                BunifuCustomDataGrid1.DataSource = bSource
                                                bSource.ResetBindings(False)
                                                BunifuCustomDataGrid1.Refresh()

                                            End Using
                                        End Using
                                    End Using
                                    pan2.Visible = False
                                    tb2.Text = ""

                                End If
                            End Using
                        End Using
                    End If
                End If
            End Using
        End Using

    End Sub
End Class
