Imports MySql.Data.MySqlClient


Public Class Form1
    Public a As String
    Dim b As String
    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

        If a = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            Panel1.Visible = True
            Using con As New MySqlConnection(myConnectionString)
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =  " & a, conn)
                    cmd.CommandType = CommandType.Text
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            datagrid2.DataSource = dt
                            datagrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                            datagrid2.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            datagrid2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            datagrid2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            datagrid2.Columns(0).HeaderCell.Value = "Action"
                            datagrid2.Columns(1).HeaderCell.Value = "ID"
                            datagrid2.Columns(2).HeaderCell.Value = "Model Number"
                            datagrid2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            datagrid2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                            Dim recordcount As Int32
                            Using con2 As New MySqlConnection(myConnectionString)
                                Using cmd3 As New MySqlCommand("SELECT COUNT(itemcontent.id) from items left join itemcontent on itemcontent.itemID = items.id where  itemcontent.tagID = 1 AND items.id = " & a, conn)
                                    cmd3.CommandType = CommandType.Text
                                    If IsDBNull(cmd3) Then
                                        MessageBox.Show("No record")
                                    Else
                                        Using sda1 As New MySqlDataAdapter(cmd3)
                                            recordcount = Convert.ToInt32(cmd3.ExecuteScalar())
                                            Label10.Text = "Available Stocks: " & recordcount.ToString



                                        End Using
                                    End If
                                End Using
                            End Using

                        End Using
                    End Using
                End Using
            End Using
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
        If cb2.Items.Count > 0 Then
            cb2.selectedIndex = 0    ' The first item has index 0 '
        End If
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

    Dim c As String
    Dim d As String
    Dim f As String
    Private Sub datagrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagrid2.CellContentClick
        If e.ColumnIndex = datagrid2.Columns("column2").Index Then
            DataGridViewCheckBoxColumn_Uncheck1()
            Dim cell As DataGridViewCheckBoxCell = datagrid2.Rows(e.RowIndex).Cells("column2")
            cell.Value = cell.TrueValue
            c = datagrid2.Rows(e.RowIndex).Cells(1).Value.ToString()
            d = datagrid2.Rows(e.RowIndex).Cells(2).Value.ToString()
            f = datagrid2.Rows(e.RowIndex).Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub DataGridViewCheckBoxColumn_Uncheck1()
        For Each row As DataGridViewRow In datagrid2.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("column2")
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

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
        Panel1.Visible = False
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click


        If c = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            Using con As New MySqlConnection(myConnectionString)
                Using cmd As New MySqlCommand("DELETE FROM itemcontent WHERE id =" + c, conn)
                    cmd.CommandType = CommandType.Text

                    If cmd.ExecuteNonQuery > 0 Then
                        MsgBox("Successfully Deleted", MsgBoxStyle.Exclamation, "Process Complete")

                        Using cmd1 As New MySql.Data.MySqlClient.MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =  " & a, conn)
                            cmd1.CommandType = CommandType.Text
                            Using sda As New MySqlDataAdapter(cmd1)
                                Using dt As New DataTable()


                                    sda.Fill(dt)
                                    Dim bSource As New BindingSource()
                                    bSource.DataSource = dt
                                    datagrid2.DataSource = bSource
                                    bSource.ResetBindings(False)
                                    datagrid2.Refresh()
                                    c = Nothing


                                    Dim counter As Integer
                                    Using con2 As New MySqlConnection(myConnectionString)
                                        Using cmd3 As New MySqlCommand("SELECT COUNT(itemcontent.id) from items left join itemcontent on itemcontent.itemID = items.id where  itemcontent.tagID = 1 AND items.id = " & a, conn)
                                            cmd3.CommandType = CommandType.Text
                                            If IsDBNull(cmd3) Then
                                                MessageBox.Show("No record")
                                            Else
                                                Using sda1 As New MySqlDataAdapter(cmd3)
                                                    counter = cmd3.ExecuteScalar()
                                                    Label10.Text = "Available Stocks: " & counter.ToString
                                                End Using
                                            End If
                                        End Using
                                    End Using
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

    Private Sub BunifuFlatButton12_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton12.Click
        BunifuGradientPanel1.Visible = True
    End Sub

    Private Sub BunifuCustomDataGrid2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid2.CellContentClick

    End Sub

    Private Sub BunifuGradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles pan3.Paint

    End Sub

    Private Sub BunifuDropdown1_onItemSelected(sender As Object, e As EventArgs) Handles cb2.onItemSelected

    End Sub

    Private Sub BunifuFlatButton14_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton14.Click
        Using con1 As New MySqlConnection(myConnectionString)
            Using cmd1 As New MySqlCommand("Select COUNT(*) FROM itemcontent where modelNumber ='" + BunifuMaterialTextbox1.Text + "' AND itemid=" & a, conn)
                cmd1.CommandType = CommandType.Text

                If cmd1.ExecuteScalar > 0 Then
                    MsgBox("Item is already registered.", MsgBoxStyle.Exclamation, "Error")

                Else

                    If BunifuMaterialTextbox1.Text = "" Then

                        MsgBox("Inputs cannot be blank", MsgBoxStyle.Exclamation, "Process Complete")
                    Else
                        Using con As New MySqlConnection(myConnectionString)
                            Using cmd As New MySqlCommand(" INSERT INTO `db`.`itemcontent` (`itemid`,`tagID`,`modelNumber`,`StockID`) VALUES (" & a & "," & cb2.selectedIndex + 1 & ",'" & BunifuMaterialTextbox1.Text & "'," & a & ");", conn)
                                cmd.CommandType = CommandType.Text

                                If cmd.ExecuteNonQuery > 0 Then
                                    MsgBox("Successfully added to database", MsgBoxStyle.Exclamation, "Process Complete")
                                    BunifuGradientPanel1.Visible = False
                                    BunifuMaterialTextbox1.Text = ""
                                    Using cmd2 As New MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =" & a, conn)
                                        cmd2.CommandType = CommandType.Text
                                        Using sda As New MySqlDataAdapter(cmd2)
                                            Using dt As New DataTable()
                                                sda.Fill(dt)
                                                datagrid2.DataSource = dt

                                                datagrid2.Update()
                                                Dim recordcount As Int32
                                                Using con2 As New MySqlConnection(myConnectionString)
                                                    Using cmd3 As New MySqlCommand("SELECT COUNT(itemcontent.id) from items left join itemcontent on itemcontent.itemID = items.id where  itemcontent.tagID = 1 AND items.id = " & a, conn)
                                                        cmd3.CommandType = CommandType.Text
                                                        If IsDBNull(cmd3) Then
                                                            MessageBox.Show("No record")
                                                        Else
                                                            Using sda1 As New MySqlDataAdapter(cmd3)
                                                                recordcount = Convert.ToInt32(cmd3.ExecuteScalar())
                                                                Label10.Text = "Available Stocks: " & recordcount.ToString



                                                            End Using
                                                        End If
                                                    End Using
                                                End Using
                                            End Using
                                        End Using
                                    End Using


                                End If
                            End Using
                        End Using
                    End If
                End If




            End Using
        End Using
    End Sub

    Private Sub BunifuFlatButton13_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton13.Click
        BunifuGradientPanel1.Visible = False
    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel1.Paint

    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        If c = Nothing Then
            MsgBox("No selected rows.", MsgBoxStyle.Exclamation, "Error")
        Else
            BunifuMaterialTextbox2.Text = d
            Dim o As Integer
            BunifuDropdown1.selectedIndex = 3
            For Each BunifuDropdown1 As String In Me.BunifuDropdown1.Items
                If BunifuDropdown1 = f Then

                    Exit For
                End If
                o = o + 1
            Next
            BunifuDropdown1.selectedIndex = o


            If pan3.Visible = False Then

                pan3.Visible = True

            Else
                pan3.Visible = False

            End If


        End If
    End Sub

    Private Sub BunifuFlatButton16_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton16.Click
        Using con1 As New MySqlConnection(myConnectionString)
            Using cmd1 As New MySqlCommand("Select COUNT(*) FROM itemcontent where modelNumber ='" + BunifuMaterialTextbox2.Text + "'", conn)
                cmd1.CommandType = CommandType.Text

                If BunifuMaterialTextbox2.Text = "" Then
                        MsgBox("Inputs cannot be blank.", MsgBoxStyle.Exclamation, "Process Complete")
                    Else

                        Using con As New MySqlConnection(myConnectionString)
                        Using cmd As New MySqlCommand(" UPDATE `db`.`itemcontent` SET `modelNumber`='" + BunifuMaterialTextbox2.Text + "', tagID = " & BunifuDropdown1.selectedIndex + 1 & ", StockID = " & c & " WHERE (`id` = '" & c & "');", conn)
                            cmd.CommandType = CommandType.Text

                            If cmd.ExecuteNonQuery > 0 Then
                                MsgBox("Successfully updated in the database", MsgBoxStyle.Exclamation, "Process Complete")
                                Using cmd2 As New MySqlCommand("SELECT itemcontent.id,itemcontent.modelnumber,tag.description FROM items left outer join itemcontent on itemcontent.itemID = items.id left outer join tag on itemcontent.tagID = tag.id where items.id =" & a, conn)
                                    cmd2.CommandType = CommandType.Text
                                    Using sda As New MySqlDataAdapter(cmd2)
                                        Using dt As New DataTable()
                                            sda.Fill(dt)
                                            datagrid2.DataSource = dt

                                            datagrid2.Update()
                                            Dim recordcount As Int32
                                            Using con2 As New MySqlConnection(myConnectionString)
                                                Using cmd3 As New MySqlCommand("SELECT COUNT(itemcontent.id) from items left join itemcontent on itemcontent.itemID = items.id where  itemcontent.tagID = 1 AND items.id = " & a, conn)
                                                    cmd3.CommandType = CommandType.Text
                                                    If IsDBNull(cmd3) Then
                                                        MessageBox.Show("No record")
                                                    Else
                                                        Using sda1 As New MySqlDataAdapter(cmd3)
                                                            recordcount = Convert.ToInt32(cmd3.ExecuteScalar())
                                                            Label10.Text = "Available Stocks: " & recordcount.ToString



                                                        End Using
                                                    End If
                                                End Using
                                            End Using
                                            pan3.Visible = False
                                        End Using
                                    End Using
                                End Using
                                pan2.Visible = False
                                tb2.Text = ""

                            End If
                        End Using
                    End Using
                    End If

            End Using
        End Using
    End Sub

    Private Sub cb3_onItemSelected(sender As Object, e As EventArgs)


    End Sub

    Private Sub BunifuDropdown1_onItemSelected_1(sender As Object, e As EventArgs) Handles BunifuDropdown1.onItemSelected

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click
        pan3.Visible = False
    End Sub
End Class
