Imports System.Console

Imports System.Data.SqlClient

Imports System.Data

Imports System.Data.Odbc

Module TulisFileXML

    Dim koneksi As New OdbcConnection("DSN=latihan")

    Dim perintah As OdbcCommand

    Dim myData As New DataSet


    Public Sub tulisDataXML()

        'Dim koneksi As New OdbcConnection("DSN=latihan")

        'Dim perintah As OdbcCommand

        'Dim myData As New DataSet

        Try

            koneksi.Open()

            Console.WriteLine("Koneksi Berhasil")

            Dim dAdapter As OdbcDataAdapter = New OdbcDataAdapter("SELECT * FROM pegawai;", koneksi)

            dAdapter.Fill(myData)

            myData.WriteXml("D:\StevenNathaniel\Proyek VB NET\DevExpress6\DevExpress6\datasetPegawai.xml", XmlWriteMode.WriteSchema)

            Console.WriteLine("Berhasil Tulis Data Ke XML")

            koneksi.Close()


        Catch ex As OdbcException

            Console.WriteLine("Terjadi Error : " & ex.ErrorCode & " - " & ex.Message)

        Finally

            koneksi.Dispose()


        End Try
    End Sub




End Module


Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Call tulisDataXML()



    End Sub
End Class
