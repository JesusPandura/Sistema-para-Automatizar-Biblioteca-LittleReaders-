﻿Public Class FBibliotecario
    Dim FuncBibliotecario As New DBibliotecario
    Dim DatBibliotecario As New LBibliotecario
    Private Sub FBibliotecario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarListaBibliotecario()

    End Sub

    Public Sub CargarListaBibliotecario()
        Dim CantRegistros As Integer
        Try
            dgvBibliotecario.DataSource = FuncBibliotecario.MostrarBibliotecarios
            dgvBibliotecario.Columns(0).Visible = False
            CantRegistros = dgvBibliotecario.RowCount
            lblRegistros.Text = Convert.ToString(CantRegistros)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dgvBibliotecario.ClearSelection()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim FormAgregar As New FNBibliotecario
        FormAgregar.ShowDialog()
        CargarListaBibliotecario()
    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvBibliotecario.SelectedRows.Count > 0 Then
                EliminarBibliotecario()
                CargarListaBibliotecario()
            Else
                MsgBox("Seleccione un Registro", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub EliminarBibliotecario()
        Try
            DatBibliotecario._CodBibliotecario = dgvBibliotecario.SelectedCells.Item(0).Value

            If MsgBox("¿Desea Eliminar este Registro?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If FuncBibliotecario.EliminarBibliotecario(DatBibliotecario) Then
                    MsgBox("Registro eliminado Correctamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                Else
                    MsgBox("No se pudo eliminar el Registro", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                End If
            Else
                Return
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form3 As New Fdetalles
        Form3.ShowDialog()
    End Sub
End Class